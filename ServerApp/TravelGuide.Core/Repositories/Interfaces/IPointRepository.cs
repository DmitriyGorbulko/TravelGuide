using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IPointRepository
    {
        Task<Point> Create(Point point);
        Task<Point> Update(Point point);
        Task Delete(int id);
        Task<Point> Get(int id);
        Task<IEnumerable<Point>> GetAll();
    }
}
