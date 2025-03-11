using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

[ApiController]
[Route("api/way_of_tour")]
public class WayOfTourController : ControllerBase
{
    private readonly IWayOfTourService _wayOfTourService;

    public WayOfTourController(IWayOfTourService wayOfTourService)
    {
        _wayOfTourService = wayOfTourService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<WayOfTour>> Create(int tourId, int wayId)
    {
        try
        {
            var result = await _wayOfTourService.Create(tourId, wayId);
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
    public async Task<ActionResult> Delete(WayOfTour wayOfTour)
    {
        await _wayOfTourService.Delete(wayOfTour);
        return NoContent();
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<WayOfTour>> Get(int id)
    {
        return Ok(await _wayOfTourService.Get(id));
    }

    [HttpGet]
    [Route("get_all")]
    public async Task<ActionResult<IEnumerable<WayOfTour>>> GetAll()
    {
        return Ok(await _wayOfTourService.GetAll());
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<WayOfTour>> Update(WayOfTour wayOfTour)
    {
        return Ok(await _wayOfTourService.Update(wayOfTour));
    }

    [HttpGet]
    [Route("tours_by_town")]
    public async Task<ActionResult<List<Tour>>> GetToursByTownTitle(string townTitle)
    {
        var tours = await _wayOfTourService.GetToursByTownTitle(townTitle);
        return Ok(tours);
    }

    [HttpGet]
    [Route("tours_by_way/{wayId}")]
    public async Task<ActionResult<IEnumerable<WayOfTour>>> GetByWayId(int wayId)
    {
        var wayOfTours = await _wayOfTourService.GetByWayId(wayId);

        if (wayOfTours == null || !wayOfTours.Any())
        {
            return NotFound("No tours found for this way ID.");
        }

        return Ok(wayOfTours);
    }

}
