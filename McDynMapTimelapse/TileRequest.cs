using SixLabors.ImageSharp;

namespace McDynMapTimelapse;

public class TileRequest
{
    public string? Path { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Image? ImageData { get; set; }
}