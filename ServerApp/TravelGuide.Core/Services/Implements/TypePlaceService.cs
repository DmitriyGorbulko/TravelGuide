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
    public class TypePlaceService : ITypePlaceService
    {
        private readonly ITypePlaceRepository _typePlaceRepository;

        public TypePlaceService(ITypePlaceRepository typePlaceRepository)
        {
            _typePlaceRepository = typePlaceRepository;
        }

        public async Task<TypePlace> Create(TypePlace typePlace)
        {
            return await _typePlaceRepository.Create(typePlace);
        }

        public async Task<TypePlace> Update(TypePlace typePlace)
        {
            return await _typePlaceRepository.Update(typePlace);
        }

        public async Task Delete(int id)
        {
            await _typePlaceRepository.Delete(id);
        }

        public async Task<TypePlace> Get(int id)
        {
            return await _typePlaceRepository.Get(id);
        }

        public async Task<IEnumerable<TypePlace>> GetAll()
        {
            return await _typePlaceRepository.GetAll();
        }

    }
}
