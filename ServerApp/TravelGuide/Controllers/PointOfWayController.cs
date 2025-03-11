using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Implements;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [Route("api/point_of_way")]
    [ApiController]
    public class PointOfWayController : ControllerBase
    {
        private readonly IPointOfWayService _pointOfWayService;

        public PointOfWayController(IPointOfWayService pointOfWayService)
        {
            _pointOfWayService = pointOfWayService;
        }

        [Route("/create_point_of_way")]
        [HttpPost]
        public async Task<ActionResult<PointOfWay>> Create(PointOfWay pointOfWay)
        {
            return Ok(await _pointOfWayService.Create(pointOfWay));
        }

        [Route("/update_point_of_way")]
        [HttpPut]
        public async Task<ActionResult<PointOfWay>> Update(PointOfWay pointOfWay)
        {
            return Ok(await _pointOfWayService.Update(pointOfWay));
        }

        [Route("/get_point_of_way")]
        [HttpGet]
        public async Task<ActionResult<PointOfWay>> Get(int id)
        {
            return Ok(await _pointOfWayService.Get(id));
        }

        [Route("/get_points_of_ways")]
        [HttpGet]
        public async Task<ActionResult<PointOfWay>> GetAll()
        {
            return Ok(await _pointOfWayService.GetAll());
        }

        [Route("/get_by_way_id")]
        [HttpGet]
        public async Task<ActionResult<PointOfWay>> GetByWayId(int wayId)
        {
            return Ok(await _pointOfWayService.GetByWayId(wayId));
        }


        // Если хотите передавать тип места через параметр:
        [Route("/get_points_by_type_place")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetTownsFromWay(int wayId)
        {
            return Ok(await _pointOfWayService.GetTownsFromWay(wayId));
        }

    }
}
