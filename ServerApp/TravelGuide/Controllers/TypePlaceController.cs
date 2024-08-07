using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Api.Controllers
{
    [Route("api/type_place")]
    [ApiController]
    public class TypePlaceController : ControllerBase
    {
        private readonly ITypePlaceService _typePlaceService;

        public TypePlaceController(ITypePlaceService typePlaceService)
        {
            _typePlaceService = typePlaceService;
        }

        [Route("/create_type_place")]
        [HttpPost]
        public async Task<ActionResult<TypePlace>> Create(TypePlace typePlace)
        {
            return Ok(await _typePlaceService.Create(typePlace));
        }

        [Route("/update_type_place")]
        [HttpPut]
        public async Task<ActionResult<TypePlace>> Update(TypePlace typePlace)
        {
            return Ok(await _typePlaceService.Update(typePlace));
        }

        [Route("/get_type_place")]
        [HttpGet]
        public async Task<ActionResult<TypePlace>> Get(int id)
        {
            return Ok(await _typePlaceService.Get(id));
        }

        [Route("/get_types_place")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePlace>>> GetAll()
        {
            return Ok(await _typePlaceService.GetAll());
        }

        [Route("/delete_type_place")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _typePlaceService.Delete(id);
        }
    }
}
