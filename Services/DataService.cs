using VCCTools.Models;

namespace VCCTools.Services;

public class DataService
{
    public Game Game { get; private set; }
    public Team TeamA { get; private set; }
    public Team TeamB { get; private set; }
    public List<MapPick> MapSeries { get; private set; }
    public int CurrentMapIndex { get; set; }

    public DataService()
    {
        SetDefaultData();
    }

    public void SetDefaultData()
    {
        Game = new Game();
        Game.Title = "Untitled";
        Game.Subtitle = "Unsubtitled";
        Game.Time = "1970-01-01T00:00";
        Game.Length = "BO1";

        TeamA = new Team();
        TeamA.Id = TeamId.TeamA;
        TeamA.Name = "Alpha";
        TeamA.Code = "ALP";
        TeamA.Players = new List<string>
        {
            "Player 1",
            "Player 2",
            "Player 3",
            "Player 4",
            "Player 5"
        };

        TeamB = new Team();
        TeamB.Id = TeamId.TeamB;
        TeamB.Name = "Bravo";
        TeamB.Code = "BRV";
        TeamB.Players = new List<string>
        {
            "Player 6",
            "Player 7",
            "Player 8",
            "Player 9",
            "Player 10"
        };

        MapSeries = new List<MapPick>();
        for (var i = 0; i < 7; i++)
        {
            MapSeries.Add(new MapPick
            {
                Map = "TBD",
                Team = TeamId.None,
                Type = MapPickType.None,
                IsAttacking = false,
                Result = MapPickResult.Incomplete
            });
        }

        CurrentMapIndex = 0;
    }
}