using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

namespace TravelGuide.Api.Controllers
{
    [ApiController]
    [Route("api/way_of_attraction")]
    public class WayOfAttractionController : ControllerBase
    {
        private readonly IWayOfAttractionService _wayOfAttractionService;

        public WayOfAttractionController(IWayOfAttractionService wayOfAttractionService)
        {
            _wayOfAttractionService = wayOfAttractionService;
        }

        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult<WayOfAttraction>> Create(int wayId,  int attractionId)
        {
            try{
                var result = await _wayOfAttractionService.Create(wayId, attractionId);
                return Ok(result);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка в контроллере:{ex.Message}");
                return StatusCode(500,"Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("/way_of_attractions_delete")]
        public async Task<ActionResult> Delete(WayOfAttraction wayOfAttraction)
        {
            await _wayOfAttractionService.Delete(wayOfAttraction);
            return NoContent();
        }

        [HttpGet]
        [Route("/way_of_attractions_get")]
        public async Task<ActionResult<WayOfAttraction>> Get(int id)
        {
            return Ok(await _wayOfAttractionService.Get(id));
        }

        [HttpGet]
        [Route("/way_of_attractions_get_all")]
        public async Task<ActionResult<IEnumerable<WayOfAttraction>>> GetAll()
        {
            return Ok(await _wayOfAttractionService.GetAll());
        }

        [HttpPut]
        [Route("/way_of_attractions_update")]
        public async Task<ActionResult<WayOfAttraction>> Update(WayOfAttraction wayOfAttraction)
        {
            return Ok(await _wayOfAttractionService.Update(wayOfAttraction));
        }

        [HttpGet]
        [Route("/attractions_by_town")]
        [ProducesResponseType(typeof(List<Attraction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Attraction>>> GetAttractionsByTownTitle(string townTitle)
        {
            var attractions = await _wayOfAttractionService.GetAttractionsByTownTitle(townTitle);
            Console.WriteLine($"Данные: {System.Text.Json.JsonSerializer.Serialize(attractions)}");
            return Ok(attractions);
        }

        [HttpGet]
        [Route("/way_of_attractions_by_way/{wayId}")]
        public async Task<ActionResult<IEnumerable<WayOfAttraction>>> GetByWayId(int wayId)
        {
            var wayOfAttractions = await _wayOfAttractionService.GetByWayId(wayId);

            if (wayOfAttractions == null || !wayOfAttractions.Any())
            {
                return NotFound("No attractions found for this way ID.");
            }

            return Ok(wayOfAttractions);
        }

    }
}
