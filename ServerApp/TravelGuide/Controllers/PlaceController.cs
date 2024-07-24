using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [Route("api/place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [Route("/create_place")]
        [HttpPost]
        public async Task<ActionResult<Place>> Create(Place place)
        {
            return Ok(await _placeService.Create(place));
        }

        [Route("/update_place")]
        [HttpPut]
        public async Task<ActionResult<Place>> Update(Place place)
        {
            return Ok(await _placeService.Update(place));
        }

        [Route("/get_place")]
        [HttpGet]
        public async Task<ActionResult<Place>> Get(int id)
        {
            return Ok(await _placeService.Get(id));
        }

        [Route("/get_places")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetAll()
        {
            return Ok(await _placeService.GetAll());
        }
    }
}
