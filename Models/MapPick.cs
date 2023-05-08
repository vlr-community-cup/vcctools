namespace VCCTools.Models;

public class MapPick
{
    public string Map { get; set; }
    public TeamId Team { get; set; }
    public MapPickType Type { get; set; }
    public bool IsAttacking { get; set; }
    public MapPickResult Result { get; set; }
}

public enum MapPickType
{
    None,
    Pick,
    Ban,
    Decider
}

public enum MapPickResult
{
    Incomplete,
    Victory,
    Defeat
}