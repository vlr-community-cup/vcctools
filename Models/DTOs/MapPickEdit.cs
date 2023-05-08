namespace VCCTools.Models;

public class MapPickEdit
{
    public string Map { get; set; }
    public TeamId Team { get; set; }
    public MapPickType Type { get; set; }
    public TeamId DefendingTeam { get; set; }
}