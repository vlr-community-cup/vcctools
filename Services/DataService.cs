using VCCTools.Models;

namespace VCCTools.Services;

public class DataService
{
    public Game Game { get; private set; }
    public Team TeamA { get; private set; }
    public Team TeamB { get; private set; }
    public List<MapPick> MapSeries { get; private set; }
    public int CurrentMap { get; private set; }

    public DataService()
    {
        SetDefaultData();
    }

    public void SetDefaultData()
    {
        Game = new Game();
        Game.Title = "Untitled";
        Game.Subtitle = "Unsubtitled";
        Game.Length = "BO1";
        Game.Time = "1970-01-01T00:00";

        TeamA = new Team();
        TeamA.Id = TeamId.TeamA;
        TeamA.Name = "Alpha";
        TeamA.Code = "ALP";
        TeamA.Players = new List<Player>
        {
            new Player { Name = "Player 1" },
            new Player { Name = "Player 2" },
            new Player { Name = "Player 3" },
            new Player { Name = "Player 4" },
            new Player { Name = "Player 5" }
        };

        TeamB = new Team();
        TeamB.Id = TeamId.TeamB;
        TeamB.Name = "Bravo";
        TeamB.Code = "BRV";
        TeamB.Players = new List<Player>
        {
            new Player { Name = "Player 6" },
            new Player { Name = "Player 7" },
            new Player { Name = "Player 8" },
            new Player { Name = "Player 9" },
            new Player { Name = "Player 0" }
        };

        MapSeries = new List<MapPick>();
        for (var i = 0; i < 7; i++)
        {
            var pick = new MapPick
            {
                Map = null,
                Team = TeamId.None,
                Type = MapPickType.Pick,
                DefendingTeam = TeamId.None,
                WinningTeam = TeamId.None
            };
            MapSeries.Add(pick);
        }

        CurrentMap = 0;
    }
}