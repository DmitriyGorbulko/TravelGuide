using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> Create(Review review);
        Task<Review> Update(Review review);
        Task Delete(int id);
        Task<Review> Get(int id);
        Task<IEnumerable<Review>> GetAll();
    }
}
