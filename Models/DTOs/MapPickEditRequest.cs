namespace VCCTools.Models;

public class MapPickEditRequest
{
    public string Map { get; set; }
    public TeamId Team { get; set; }
    public MapPickType Type { get; set; }
    public bool IsAttacking { get; set; }
}