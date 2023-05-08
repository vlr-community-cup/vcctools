using Microsoft.AspNetCore.Mvc;
using VCCTools.Models;
using VCCTools.Services;

namespace VCCTools.Controllers;

[ApiController]
[Route("API/Data")]
public class DataController : ControllerBase
{
    private readonly DataService _dataService;

    public DataController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public DataBundle GetDataBundle()
    {
        var bundle = new DataBundle
        {
            Game = _dataService.Game,
            TeamA = _dataService.TeamA,
            TeamB = _dataService.TeamB,
            MapSeries = _dataService.MapSeries,
            CurrentMapIndex = _dataService.CurrentMapIndex
        };
        return bundle;
    }
}