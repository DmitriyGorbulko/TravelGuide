using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface ITagOfPlaceRepository
    {
        Task<TagOfPlace> Create(TagOfPlace tagOfPlace);
        Task<TagOfPlace> Update(TagOfPlace tagOfPlace);
        Task Delete(int id);
        Task<TagOfPlace> Get(int id);
        Task<IEnumerable<TagOfPlace>> GetAll();
    }
}
