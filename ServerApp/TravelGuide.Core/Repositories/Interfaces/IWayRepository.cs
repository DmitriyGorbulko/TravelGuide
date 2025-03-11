using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IWayRepository
    {
        Task<Way> Creare(Way way);
        Task<Way> Update(Way way);
        Task Delete(int id);
        Task<IEnumerable<Way>> GetAll();
        Task<Way> Get(int id);
        Task<IEnumerable<Way>> GetByUserId(int id);
    }
}
