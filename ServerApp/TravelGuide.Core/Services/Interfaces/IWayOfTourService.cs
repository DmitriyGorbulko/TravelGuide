using System.Collections.Generic;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IWayOfTourService
    {
        Task<WayOfTour> Create(int tourId, int wayId);
        Task Delete(WayOfTour wayOfTour);
        Task<WayOfTour> Get(int id);
        Task<IEnumerable<WayOfTour>> GetAll();
        Task<WayOfTour> Update(WayOfTour wayOfTour);

        Task<List<Tour>> GetToursByTownTitle(string townTitle);
        Task<IEnumerable<WayOfTour>> GetByWayId(int wayId);
    }
}
