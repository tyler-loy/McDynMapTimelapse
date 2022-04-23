using System.Numerics;

namespace McDynMapTimelapse;

public class TimelapseConfig
{
    public string Url { get; set; }
    public string WorldName { get; set; }
    public string MapName { get; set; }
    public string TargetDir { get; set; }
    public MinecraftPosition CenterPos { get; set; }
    public int SizeW { get; set; }
    public int SizeH { get; set; }
    public int Zoom { get; set; }
    public bool Enabled { get; set; }
    public float ChangeFactor { get; set; }
}

public class MinecraftPosition
{
    
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
}


public class TimelapseWorkerConfig
{   
    public List<TimelapseConfig> Configs { get; set; }
    public int RunWaitTimeMs { get; set; }
}