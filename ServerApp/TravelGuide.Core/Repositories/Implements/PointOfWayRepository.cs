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
    public class PointOfWayRepository : IPointOfWayRepository
    {
        readonly TravelGuideDbContext _context;

        public PointOfWayRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<PointOfWay> Create(PointOfWay pointOfWay)
        {
            await _context.PointOfWays.AddAsync(pointOfWay);
            await _context.SaveChangesAsync();
            return pointOfWay;
        }

        public async Task Delete(int id)
        {
            var pointOfWay = await _context.PointOfWays
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            _context.PointOfWays.Remove(pointOfWay);
            await _context.SaveChangesAsync();
        }

        public async Task<PointOfWay> Get(int id)
        {
            return await _context.PointOfWays.FindAsync(id);
        }

        public async Task<IEnumerable<PointOfWay>> GetAll()
        {
            return await _context.PointOfWays.ToListAsync();
        }

        public async Task<PointOfWay> Update(PointOfWay pointOfWay)
        {
            var pointOfWayUpdate = await _context.PointOfWays.FindAsync(pointOfWay.Id);
            pointOfWayUpdate.WayId = pointOfWay.WayId;
            await _context.SaveChangesAsync();
            return pointOfWay;
        }
    }
}
