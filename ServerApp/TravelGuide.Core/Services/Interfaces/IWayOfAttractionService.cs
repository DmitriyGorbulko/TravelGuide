using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IWayOfAttractionService
    {
        Task<WayOfAttraction> Create(int wayId, int attractionId);
        Task Delete(WayOfAttraction wayOfAttraction);
        Task<WayOfAttraction> Get(int id);
        Task<IEnumerable<WayOfAttraction>> GetAll();
        Task<WayOfAttraction> Update(WayOfAttraction wayOfAttraction);

        Task<IEnumerable<Attraction>> GetAttractionsByTownTitle(string townTitle);
        Task<IEnumerable<WayOfAttraction>> GetByWayId(int wayId);
    }
}
