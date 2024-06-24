using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        [Route("/create_place")]
        public async Task<ActionResult<Place>> Create([FromBody] Place place)
        {
            return Ok(await _placeService.Create(place));
        }

        [HttpPut]
        [Route("/update_place")]
        public async Task<ActionResult<Place>> Update(Place place)
        {
            return Ok(await _placeService.Update(place));
        }

        [HttpGet]
        [Route("/get_place")]
        public async Task<ActionResult<Place>> Get(int id)
        {
            return Ok(await _placeService.Get(id));
        }

        [HttpGet]
        [Route("/get_all_places")]
        public async Task<ActionResult<IEnumerable<Place>>> GetAll()
        {
            return Ok(await _placeService.GetAll());
        }

        [HttpDelete]
        [Route("/remove_place")]
        public async Task Delete(int id)
        {
            await _placeService.Delete(id);
        }
    }
}
