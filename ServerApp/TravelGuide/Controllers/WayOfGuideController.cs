using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

[ApiController]
[Route("api/way_of_guide")]
public class WayOfGuideController : ControllerBase
{
    private readonly IWayOfGuideService _wayOfGuideService;

    public WayOfGuideController(IWayOfGuideService wayOfGuideService)
    {
        _wayOfGuideService = wayOfGuideService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<WayOfGuide>> Create(int guideId, int wayId)
    {
        try
        {
            var result = await _wayOfGuideService.Create(guideId, wayId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка в контроллере: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> Delete(WayOfGuide wayOfGuide)
    {
        await _wayOfGuideService.Delete(wayOfGuide);
        return NoContent();
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<WayOfGuide>> Get(int id)
    {
        return Ok(await _wayOfGuideService.Get(id));
    }

    [HttpGet]
    [Route("get_all")]
    public async Task<ActionResult<IEnumerable<WayOfGuide>>> GetAll()
    {
        return Ok(await _wayOfGuideService.GetAll());
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<WayOfGuide>> Update(WayOfGuide wayOfGuide)
    {
        return Ok(await _wayOfGuideService.Update(wayOfGuide));
    }

    [HttpGet]
    [Route("guides_by_town")]
    public async Task<ActionResult<List<Guide>>> GetGuidesByTownTitle(string townTitle)
    {
        var guides = await _wayOfGuideService.GetGuidesByTownTitle(townTitle);
        return Ok(guides);
    }

    [HttpGet]
    [Route("way_of_guides_by_way/{wayId}")]
    public async Task<ActionResult<IEnumerable<WayOfGuide>>> GetByWayId(int wayId)
    {
        var wayOfGuides = await _wayOfGuideService.GetByWayId(wayId);

        if (wayOfGuides == null || !wayOfGuides.Any())
        {
            return NotFound("No guides found for this way ID.");
        }

        return Ok(wayOfGuides);
    }

}
