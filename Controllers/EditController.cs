using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VCCTools.Hubs;
using VCCTools.Models;
using VCCTools.Services;

namespace VCCTools.Controllers;

[ApiController]
[Route("API/Edit")]
public class EditController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly IHubContext<EventHub> _hubContext;

    public EditController(DataService dataService, IHubContext<EventHub> hubContext)
    {
        _dataService = dataService;
        _hubContext = hubContext;
    }

    [HttpPost("Game")]
    public async Task<IActionResult> EditGameInfo([FromBody] GameInfo gameInfo)
    {
        _dataService.Game.Title = gameInfo.Title;
        _dataService.Game.Subtitle = gameInfo.Subtitle;
        _dataService.Game.Length = gameInfo.Length;
        _dataService.Game.Time = gameInfo.Time;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpPost("Teams")]
    public async Task<IActionResult> EditTeamInfo([FromBody] TeamInfo teamInfo)
    {
        _dataService.TeamA.Name = teamInfo.TeamAName;
        _dataService.TeamA.Code = teamInfo.TeamACode;
        _dataService.TeamB.Name = teamInfo.TeamBName;
        _dataService.TeamB.Code = teamInfo.TeamBCode;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpPost("Map/{index}")]
    public async Task<IActionResult> EditMapPick([FromRoute] int index, [FromBody] MapPickEdit mapPickEdit)
    {
        var mapPick = _dataService.MapSeries[index];
        mapPick.Map = mapPickEdit.Map;
        mapPick.Team = mapPickEdit.Team;
        mapPick.Type = mapPickEdit.Type;
        mapPick.DefendingTeam = mapPickEdit.DefendingTeam;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpGet("Map/{index}/{teamId}")]
    public async Task<IActionResult> EditMapWinner([FromRoute] int index, [FromRoute] TeamId teamId)
    {
        var mapPick = _dataService.MapSeries[index];
        mapPick.WinningTeam = teamId;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }
}