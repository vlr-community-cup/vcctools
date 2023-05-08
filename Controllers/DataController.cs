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
        var bundle = new DataBundle(
            _dataService.Game,
            _dataService.TeamA,
            _dataService.TeamB,
            _dataService.MapSeries,
            _dataService.CurrentMap
        );
        return bundle;
    }
}