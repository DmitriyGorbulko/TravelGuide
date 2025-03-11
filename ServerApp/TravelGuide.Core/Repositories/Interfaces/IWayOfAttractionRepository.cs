using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IWayOfAttractionRepository
    {
        Task<WayOfAttraction> Create(WayOfAttraction wayOfAttraction);
        Task Delete(WayOfAttraction wayOfAttraction);
        Task<WayOfAttraction> Get(int id);
        Task<IEnumerable<WayOfAttraction>> GetAll();
        Task<WayOfAttraction> Update(WayOfAttraction wayOfAttraction);
        Task<IEnumerable<WayOfAttraction>> GetByWayId(int wayId);
    }
}
