using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IWayOfGuideService
    {
        Task<WayOfGuide> Create(int guideId, int wayId);
        Task Delete(WayOfGuide wayOfGuide);
        Task<WayOfGuide> Get(int id);
        Task<IEnumerable<WayOfGuide>> GetAll();
        Task<WayOfGuide> Update(WayOfGuide wayOfGuide);

        Task<IEnumerable<Guide>> GetGuidesByTownTitle(string townTitle);
        Task<IEnumerable<WayOfGuide>> GetByWayId(int wayId);
    }
}
