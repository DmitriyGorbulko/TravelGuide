using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IFavoriteTagRepository
    {
        Task<FavoriteTag> Create(FavoriteTag favoriteTag);
        Task<FavoriteTag> Update(FavoriteTag favoriteTag);
        Task Delete(int id);
        Task<FavoriteTag> Get(int id);
        Task<IEnumerable<FavoriteTag>> GetAll();
    }
}
