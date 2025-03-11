using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IWayOfGuideRepository
    {
        Task<WayOfGuide> Create(WayOfGuide wayOfGuide);
        Task Delete(WayOfGuide wayOfGuide);
        Task<WayOfGuide> Get(int id);
        Task<IEnumerable<WayOfGuide>> GetAll();
        Task<WayOfGuide> Update(WayOfGuide wayOfGuide);
        Task<IEnumerable<WayOfGuide>> GetByWayId(int wayId);
    }
}
