namespace VCCTools.Models;

public class DataBundle
{
    public Game Game { get; set; }
    public Team TeamA { get; set; }
    public Team TeamB { get; set; }
    public int CurrentMapIndex { get; set; }
    public List<MapPick> MapSeries { get; set; }
}