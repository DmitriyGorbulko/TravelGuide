using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    public class TypePlaceController : ControllerBase
    {
        private readonly ITypePlaceService _typePlaceService;

        public TypePlaceController(ITypePlaceService typePlaceService)
        {
            _typePlaceService = typePlaceService;
        }

        [HttpPost]
        [Route("/create_type_place")]
        public async Task<ActionResult<TypePlace>> Create(TypePlace typePlace)
        {
            return Ok(await _typePlaceService.Create(typePlace));
        }

        [HttpPut]
        [Route("/update_type_place")]
        public async Task<ActionResult<TypePlace>> Update(TypePlace typePlace)
        {
            return Ok(await _typePlaceService.Update(typePlace));
        }

        [HttpGet]
        [Route("/get_type_place")]
        public async Task<ActionResult<TypePlace>> Get(int id)
        {
            return Ok(await _typePlaceService.Get(id));
        }

        [HttpGet]
        [Route("/get_all_type_place")]
        public async Task<ActionResult<IEnumerable<TypePlace>>> GetAll()
        {
            return Ok(await _typePlaceService.GetAll());
        }

        [HttpDelete]
        [Route("/remove_type_place")]
        public async Task Delete(int id)
        {
            await _typePlaceService.Delete(id);
        }
    }
}
