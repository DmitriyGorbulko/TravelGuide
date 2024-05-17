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
    public class WayService : IWayService
    {
        private readonly IWayRepository _wayRepository;

        public WayService(IWayRepository wayRepository)
        {
            _wayRepository = wayRepository;
        }

        public async Task<Way> Create(Way way)
        {
            return await _wayRepository.Creare(way);
        }

        public Task Delete(Way way)
        {
            throw new NotImplementedException();
        }

        public async Task<Way> Get(int id)
        {
            return await _wayRepository.Get(id);
        }

        public async Task<IEnumerable<Way>> GetAll()
        {
            return await _wayRepository.GetAll();
        }

        public async Task<Way> Update(Way way)
        {
            return await _wayRepository.Update(way);
        }
    }
}
