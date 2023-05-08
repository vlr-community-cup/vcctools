namespace VCCTools.Models;

public class Team
{
    public TeamId Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public List<Player> Players { get; set; }
}

public enum TeamId
{
    None,
    TeamA,
    TeamB
}