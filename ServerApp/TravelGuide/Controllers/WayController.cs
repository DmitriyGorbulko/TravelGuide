using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [ApiController]
    [Route("api/way")]
    public class WayController : ControllerBase
    {
        private readonly IWayService _wayService;

        public WayController(IWayService wayService)
        {
            _wayService = wayService;
        }

        [HttpPost]
        [Route("/create_way")]
        public async Task<ActionResult<Way>> Create(Way way)
        {
            return Ok(await _wayService.Create(way));
        }

        [HttpPut]
        [Route("/update_way")]
        public async Task<ActionResult<Way>> Update(Way way) 
        {
            return Ok(await _wayService.Update(way));
        }

        [HttpGet]
        [Route("/get_way")]
        public async Task<ActionResult<Way>> Get(int id)
        {
            return Ok(await  (_wayService.Get(id)));
        }

        [HttpGet]
        [Route("/get_ways")]
        public async Task<ActionResult<IEnumerable<Way>>> GetAll() 
        {
            return Ok(await _wayService.GetAll());
        }

        [HttpDelete]
        [Route("/remove_way")]
        public async Task Delete(int id)
        {
            await _wayService.Delete(id);
        }
    }
}
