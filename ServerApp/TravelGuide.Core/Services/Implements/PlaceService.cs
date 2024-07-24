using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Services.Implements
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Place> Create(Place place)
        {
            return await _placeRepository.Create(place);
        }

        public async Task Delete(int id)
        {
            await _placeRepository.Delete(id);
        }

        public async Task<Place> Get(int id)
        {
            return await _placeRepository.Get(id);
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _placeRepository.GetAll();
        }

        public async Task<Place> Update(Place place)
        {
            return await _placeRepository.Update(place);
        }
    }
}
