using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        Task<Place> Create(Place place);
        Task<Place> Update(Place place);
        Task<Place> Get(int id);
        Task<IEnumerable<Place>> GetAll();
        Task Delete(int id);
    }
}
