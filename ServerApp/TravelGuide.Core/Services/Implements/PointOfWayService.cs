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
    public class PointOfWayService : IPointOfWayService
    {
        private readonly IPointOfWayRepository _pointOfWayRepository;

        public PointOfWayService(IPointOfWayRepository pointOfWayRepository)
        {
            _pointOfWayRepository = pointOfWayRepository;
        }

        public async Task<PointOfWay> Create(PointOfWay pointOfWay)
        {
            return await _pointOfWayRepository.Create(pointOfWay);
        }

        public async Task Delete(int id)
        {
            await _pointOfWayRepository.Delete(id);
        }

        public async Task<PointOfWay> Get(int id)
        {
            return await _pointOfWayRepository.Get(id);
        }

        public async Task<IEnumerable<PointOfWay>> GetAll()
        {
            return await _pointOfWayRepository.GetAll();
        }

        public async Task<PointOfWay> Update(PointOfWay pointOfWay)
        {
            return await _pointOfWayRepository.Update(pointOfWay);
        }
    }
}
