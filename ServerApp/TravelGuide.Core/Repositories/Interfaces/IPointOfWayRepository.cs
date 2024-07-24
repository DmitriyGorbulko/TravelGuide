using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IPointOfWayRepository
    {
        Task<PointOfWay> Create(PointOfWay pointOfWay);
        Task<PointOfWay> Update(PointOfWay pointOfWay);
        Task Delete(int id);
        Task<PointOfWay> Get(int id);
        Task<IEnumerable<PointOfWay>> GetAll();
    }
}
