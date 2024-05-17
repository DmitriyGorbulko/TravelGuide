using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IWayService
    {
        Task<Way> Create(Way way);
        Task<Way> Update(Way way);
        Task Delete(Way way);
        Task<IEnumerable<Way>> GetAll();
        Task<Way> Get(int id);
    }
}
