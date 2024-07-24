using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> Create(Tag tag);

        Task<Tag> Update(Tag tag);

        Task Delete(int id);

        Task<Tag> Get(int id);

        Task<IEnumerable<Tag>> GetAll();
    }
}
