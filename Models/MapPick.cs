namespace VCCTools.Models;

public class MapPick
{
    public string Map { get; set; }
    public TeamId Team { get; set; }
    public MapPickType Type { get; set; }
    public TeamId DefendingTeam { get; set; }
    public TeamId WinningTeam { get; set; }

    public string GetTextForm(string teamACode, string teamBCode)
    {
        if (Map == null)
            return "TBD";

        var pickingTeam = Team == TeamId.TeamA ? teamACode : teamBCode;

        if (Type == MapPickType.Ban)
            return $"{pickingTeam} ban {Map}";

        var side = DefendingTeam == Team ? "defends" : "attacks";
        return $"{pickingTeam} {side} on {Map}";
    }
}

public enum MapPickType
{
    Pick,
    Ban,
    Decider
}