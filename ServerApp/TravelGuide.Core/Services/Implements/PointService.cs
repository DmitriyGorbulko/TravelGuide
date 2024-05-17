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
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public async Task<Point> Create(Point point)
        {
            return await _pointRepository.Create(point);
        }

        public async Task Delete(int id)
        {
            await _pointRepository.Delete(id);
        }

        public async Task<Point> Get(int id)
        {
            return await _pointRepository.Get(id);
        }

        public async Task<IEnumerable<Point>> GetAll()
        {
            return await _pointRepository.GetAll();
        }

        public async Task<Point> Update(Point point)
        {
            return await _pointRepository.Update(point);
        }
    }
}
