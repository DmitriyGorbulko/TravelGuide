using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IWayOfTourRepository
    {
        Task<WayOfTour> Create(WayOfTour wayOfTour);
        Task Delete(WayOfTour wayOfTour);
        Task<WayOfTour> Get(int id);
        Task<IEnumerable<WayOfTour>> GetAll();
        Task<WayOfTour> Update(WayOfTour wayOfTour);
        Task<IEnumerable<WayOfTour>> GetByWayId(int wayId);
    }
}
