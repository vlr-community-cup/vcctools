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
    public async Task<IActionResult> EditGameInfo([FromBody] GameInfoEditRequest editRequest)
    {
        _dataService.Game.Title = editRequest.Title;
        _dataService.Game.Subtitle = editRequest.Subtitle;
        _dataService.Game.Length = editRequest.Length;
        _dataService.Game.Time = editRequest.Time;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpPost("Teams")]
    public async Task<IActionResult> EditTeamInfo([FromBody] TeamInfoEditRequest editRequest)
    {
        _dataService.TeamA.Name = editRequest.TeamAName;
        _dataService.TeamA.Code = editRequest.TeamACode;
        _dataService.TeamB.Name = editRequest.TeamBName;
        _dataService.TeamB.Code = editRequest.TeamBCode;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpGet("Map/Current/{index}")]
    public async Task<IActionResult> EditCurrentMapIndex([FromRoute] int index)
    {
        if (index >= _dataService.MapSeries.Count)
            return BadRequest();

        _dataService.CurrentMapIndex = index;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpPost("Map/{index}")]
    public async Task<IActionResult> EditMapPick([FromRoute] int index, [FromBody] MapPickEditRequest editRequest)
    {
        var mapPick = _dataService.MapSeries[index];
        mapPick.Map = editRequest.Map;
        mapPick.Team = editRequest.Team;
        mapPick.Type = editRequest.Type;
        mapPick.IsAttacking = editRequest.IsAttacking;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }

    [HttpGet("Map/{index}/{result}")]
    public async Task<IActionResult> EditMapPickResult([FromRoute] int index, [FromRoute] MapPickResult result)
    {
        var mapPick = _dataService.MapSeries[index];
        mapPick.Result = result;

        await _hubContext.Clients.All.SendAsync("DataDidUpdate");

        return NoContent();
    }
}