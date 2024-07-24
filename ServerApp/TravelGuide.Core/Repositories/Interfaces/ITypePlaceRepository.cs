using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface ITypePlaceRepository
    {
        Task<TypePlace> Create(TypePlace typePlace);

        Task<TypePlace> Update(TypePlace typePlace);

        Task Delete(int id);

        Task<TypePlace> Get(int id);

        Task<IEnumerable<TypePlace>> GetAll();
    }
}
