using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [Route("api/point")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;

        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [Route("/create_point")]
        [HttpPost]
        public async Task<ActionResult<Point>> Create(Point point)
        {
            return Ok(await _pointService.Create(point));
        }

        [Route("/update_point")]
        [HttpPut]
        public async Task<ActionResult<Point>> Update(Point point)
        {
            return Ok(await _pointService.Update(point));
        }

        [Route("/get_point")]
        [HttpGet]
        public async Task<ActionResult<Point>> Get(int id)
        {
            return Ok(await _pointService.Get(id));
        }

        [Route("/get_points")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetAll()
        {
            return Ok(await _pointService.GetAll());
        }

    }
}
