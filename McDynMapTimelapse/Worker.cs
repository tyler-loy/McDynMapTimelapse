using System.Diagnostics;
using System.Numerics;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace McDynMapTimelapse;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly TimelapseWorkerConfig _timelapseWorkerConfig;


   // private const string url = "http://10.0.0.110:8123/";
   // private const string worldName = "world";
   // private const string mapName = "flat";
   // private const string targetDir = "C:\\temp\\mctimelapse\\img";
   // private readonly Vector3 center = new Vector3(456, 64, -1880);
   // private readonly int sizeH = 10;
   // private readonly int sizeW = 10;
    
    public Worker(ILogger<Worker> logger, TimelapseWorkerConfig timelapseWorkerConfig)
    {
        _logger = logger;
        _timelapseWorkerConfig = timelapseWorkerConfig;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var timelapseConfig in _timelapseWorkerConfig.Configs.Where(x => x.Enabled))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(timelapseConfig.Url);
                var configString = await client.GetStringAsync("/up/configuration", stoppingToken);

                var config = JsonConvert.DeserializeObject<DynMapConfig>(configString);

                if (config == null)
                {
                    throw new Exception("failed to get dynmap config");
                }

                var world = config.Worlds.FirstOrDefault(x => x.Name.ToLower() == timelapseConfig.WorldName);

                if (world is null)
                {
                    throw new Exception("Failed to find world by name.");
                }

                var map = world.Maps.FirstOrDefault(x => x.Name.ToLower() == timelapseConfig.MapName);

                if (map is null)
                {
                    throw new Exception("Failed to find map by name.");
                }

                int zoomFactor = (int)Math.Pow(2, timelapseConfig.Zoom);

                var xx = map.Worldtomap[0] * timelapseConfig.CenterPos.X + map.Worldtomap[1] * timelapseConfig.CenterPos.Y + map.Worldtomap[2] * timelapseConfig.CenterPos.Z;
                var yy = map.Worldtomap[3] * timelapseConfig.CenterPos.X + map.Worldtomap[4] * timelapseConfig.CenterPos.Y + map.Worldtomap[5] * timelapseConfig.CenterPos.Z;

                var tileX = zoomFactor * Math.Ceiling((xx / 128) / zoomFactor);
                var tileY = zoomFactor * Math.Ceiling(-(128 - yy) / 128 / zoomFactor);

                var tempX = zoomFactor * Math.Ceiling(tileX / zoomFactor);
                var tempY = zoomFactor * Math.Ceiling(tileY / zoomFactor);

                var fromX = tempX - timelapseConfig.SizeW * zoomFactor;
                var toX = tempX + timelapseConfig.SizeW * zoomFactor;
                var fromY = tempY + timelapseConfig.SizeH * zoomFactor;
                var toY = tempY - timelapseConfig.SizeH * zoomFactor;

                using Image<Rgba32> dest = new Image<Rgba32>(timelapseConfig.SizeW * 128 * 2, timelapseConfig.SizeH * 128 * 2);

                _logger.LogInformation($"Image is {dest.Width} x {dest.Height}");

                int imgX = 0;
                int imgY = 0;

                var sw = Stopwatch.StartNew();

                _logger.LogInformation("Downloading images");

                List<TileRequest> requests = new List<TileRequest>();

                foreach (var x in EnumerableUtilities.RangePython((int)fromX, (int)toX, zoomFactor))
                {
                    foreach (var y in EnumerableUtilities.RangePython((int)fromY, (int)toY, zoomFactor))
                    {
                        var chunkX = Math.Floor(x / 32.0);
                        var chunkY = Math.Floor(y / 32.0);
                        var path = $"/tiles/{timelapseConfig.WorldName}/{map.Prefix}/{(int)chunkX}_{(int)chunkY}/{GetZoomString(timelapseConfig.Zoom)}{x}_{y}.png";
                        //_logger.LogInformation(path);

                        requests.Add(new TileRequest
                        {
                            Path = path,
                            X = imgX,
                            Y = imgY
                        });


                        //var imageData = await client.GetByteArrayAsync(path, stoppingToken);
                        //Image i = Image.Load(imageData);

                        //dest.Mutate(x => x.DrawImage(i, new Point(imgX, imgY), 1f));

                        imgY += 128;
                    }

                    imgX += 128;
                    imgY = 0;
                }

                await Parallel.ForEachAsync(requests, stoppingToken, async (request, token) =>
                {
                    var imageData = await client.GetByteArrayAsync(request.Path, stoppingToken);
                    request.ImageData = Image.Load(imageData);
                });

                foreach (var tileRequest in requests)
                {
                    dest.Mutate(x => x.DrawImage(tileRequest.ImageData, new Point(tileRequest.X, tileRequest.Y), 1f));
                }

                sw.Stop();

                _logger.LogInformation($"Done Downloading Images Took {sw.Elapsed.TotalSeconds:F4} Seconds");

                var found = Directory.EnumerateFiles(timelapseConfig.TargetDir).Select(x => new FileInfo(x)).OrderByDescending(x => x.CreationTimeUtc).FirstOrDefault();

                bool shouldSave = false;

                if (found != null)
                {
                    using var f = (await Image.LoadAsync(found.FullName, stoppingToken)).CloneAs<Rgba32>();

                    long difCount = 0;

                    dest.ProcessPixelRows(f, (accessor1, accessor2) =>
                    {
                        for (int y = 0; y < accessor1.Height; y++)
                        {
                            Span<Rgba32> pixelRow1 = accessor1.GetRowSpan(y);
                            Span<Rgba32> pixelRow2 = accessor2.GetRowSpan(y);

                            // pixelRow.Length has the same value as accessor.Width,
                            // but using pixelRow.Length allows the JIT to optimize away bounds checks:
                            for (int x = 0; x < pixelRow1.Length; x++)
                            {
                                // Get a reference to the pixel at position x
                                ref Rgba32 pixel1 = ref pixelRow1[x];
                                ref Rgba32 pixel2 = ref pixelRow2[x];
                                if (pixel1 != pixel2)
                                {
                                    difCount++;
                                }
                            }
                        }
                    });

                    var totalPix = dest.Height * dest.Width;

                    double percentDif = difCount / (double)totalPix;

                    var timePassed = DateTime.UtcNow - found.CreationTimeUtc;

                    var hours = timePassed.TotalHours;

                    var percentTarget = timelapseConfig.ChangeFactor / hours;

                    _logger.LogInformation($"Image has {difCount} new pixels. Target % Changed is {percentTarget:P4} actual percent changed is {percentDif:P4}");

                    if (percentDif > percentTarget)
                    {
                        shouldSave = true;
                    }

                    if (difCount == 0)
                    {
                        shouldSave = false;
                    }
                }
                else
                {
                    shouldSave = true;
                }

                if (shouldSave)
                {
                    var fileName = $"{timelapseConfig.TargetDir}\\{timelapseConfig.WorldName}_{timelapseConfig.MapName}_{DateTime.UtcNow.ToString("yyyyMMddTHHmmss")}.png";

                    _logger.LogInformation($"Saving file {fileName}");

                    await dest.SaveAsPngAsync(fileName, stoppingToken);
                }
            }


            await Task.Delay(TimeSpan.FromMilliseconds(_timelapseWorkerConfig.RunWaitTimeMs), stoppingToken);
        }
    }

    private string GetZoomString(int timelapseConfigZoom)
    {
        if (timelapseConfigZoom == 0)
        {
            return String.Empty;
        }

        var s = new string('z', timelapseConfigZoom);

        return $"{s}_";
    }

}


public static class EnumerableUtilities
{
    public static IEnumerable<int> RangePython(int start, int stop, int step = 1)
    {
        if (step == 0)
            throw new ArgumentException("Parameter step cannot equal zero.");

        step = Math.Abs(step);
        
        if (start < stop)
        {
            step *= 1;
            for (var i = start; i < stop; i += step)
            {
                yield return i;
            }
        }
        else if (start > stop)
        {
            step *= -1;
            for (var i = start; i > stop; i += step)
            {
                yield return i;
            }
        }
    }

    public static IEnumerable<int> RangePython(int stop)
    {
        return RangePython(0, stop);
    }
}