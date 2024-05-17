using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Db;
using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Implements
{
    public class PointRepository : IPointRepository
    {
        private readonly TravelGuideDbContext _context;

        public PointRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<Point> Create(Point point)
        {
            await _context.Points.AddAsync(point);
            await _context.SaveChangesAsync();
            return point;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Point> Get(int id)
        {
            return await _context.Points.FindAsync(id);
        }

        public async Task<IEnumerable<Point>> GetAll()
        {
            return await _context.Points.ToListAsync();
        }

        public async Task<Point> Update(Point point)
        {
            var pointUpdate = await Get(point.Id);
            pointUpdate.X = point.X;
            pointUpdate.Y = point.Y;

            await _context.SaveChangesAsync();
            return pointUpdate;
        }
    }
}
