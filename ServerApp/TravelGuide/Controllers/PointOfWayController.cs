using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Implements;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [Route("api/point_of_way")]
    [ApiController]
    public class PointOfWayController : ControllerBase
    {
        private readonly PointOfWayService _pointOfWayService;

        public PointOfWayController(PointOfWayService pointOfWayService)
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
    }
}
