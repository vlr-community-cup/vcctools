namespace VCCTools.Models;

public class DataBundle
{
    public Dictionary<string, dynamic> Game { get; set; }
    public Dictionary<string, dynamic> TeamA { get; set; }
    public Dictionary<string, dynamic> TeamB { get; set; }
    public List<Dictionary<string, dynamic>> MapSeries { get; set; }
    public int CurrentMapIndex { get; set; }
    public Dictionary<string, dynamic> CurrentMap { get; set; }

    public DataBundle(Game game, Team teamA, Team teamB, List<MapPick> mapSeries, int currentMap)
    {
        Game = new Dictionary<string, dynamic>();
        Game.Add("title", game.Title);
        Game.Add("subtitle", game.Subtitle);
        Game.Add("time", game.Time);
        Game.Add("length", game.Length);

        TeamA = new Dictionary<string, dynamic>();
        TeamA.Add("name", teamA.Name);
        TeamA.Add("code", teamA.Code);
        TeamA.Add("players", teamA.Players.Select(p => p.Name).ToList());
        TeamA.Add("score", mapSeries.Count(m => m.WinningTeam == TeamId.TeamA));

        TeamB = new Dictionary<string, dynamic>();
        TeamB.Add("name", teamB.Name);
        TeamB.Add("code", teamB.Code);
        TeamB.Add("players", teamB.Players.Select(p => p.Name).ToList());
        TeamB.Add("score", mapSeries.Count(m => m.WinningTeam == TeamId.TeamB));

        MapSeries = mapSeries.Select(map =>
        {
            var dict = new Dictionary<string, dynamic>();
            dict.Add("map", map.Map);
            dict.Add("team", map.Team);
            dict.Add("isPick", map.Type == MapPickType.Pick);
            dict.Add("isBan", map.Type == MapPickType.Ban);
            dict.Add("isDecider", map.Type == MapPickType.Decider);
            dict.Add("defendingTeam", map.DefendingTeam);
            dict.Add("winningTeam", map.WinningTeam);
            dict.Add("text", map.GetTextForm(teamA.Code, teamB.Code));
            return dict;
        }).ToList();

        CurrentMapIndex = currentMap;
        CurrentMap = mapSeries.GetRange(currentMap, 1).Select(map =>
        {
            var dict = new Dictionary<string, dynamic>();
            dict.Add("map", map.Map);
            dict.Add("team", map.Team);
            dict.Add("isPick", map.Type == MapPickType.Pick);
            dict.Add("isBan", map.Type == MapPickType.Ban);
            dict.Add("defendingTeam", map.DefendingTeam);
            dict.Add("winningTeam", map.WinningTeam);
            dict.Add("text", map.GetTextForm(teamA.Code, teamB.Code));
            return dict;
        }).FirstOrDefault();
    }
}