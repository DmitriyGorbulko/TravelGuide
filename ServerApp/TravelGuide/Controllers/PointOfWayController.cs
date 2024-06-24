using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    public class PointOfWayController : ControllerBase
    {
        private readonly IPointOfWayService _pointOfWayService;

        public PointOfWayController(IPointOfWayService pointOfWayService)
        {
            _pointOfWayService = pointOfWayService;
        }

        [HttpPost]
        [Route("/create_point_of_way")]
        public async Task<ActionResult<PointOfWay>> Create(PointOfWay pointOfWay)
        {
            return Ok(await _pointOfWayService.Create(pointOfWay));
        }

        [HttpPut]
        [Route("/update_point_of_way")]
        public async Task<ActionResult<PointOfWay>> Update(PointOfWay pointOfWay)
        {
            return Ok(await _pointOfWayService.Update(pointOfWay));
        }

        [HttpGet]
        [Route("/get_point_of_way")]
        public async Task<ActionResult<PointOfWay>> Get(int id)
        {
            return Ok(await _pointOfWayService.Get(id));
        }

        [HttpGet]
        [Route("/get_all_point_of_way")]
        public async Task<ActionResult<IEnumerable<PointOfWay>>> Get()
        {
            return Ok(await _pointOfWayService.GetAll());
        }

        [HttpDelete]
        [Route("/remove_point_of_way")]
        public async Task Delete(int id)
        {
            await _pointOfWayService.Delete(id);
        }
    }
}
