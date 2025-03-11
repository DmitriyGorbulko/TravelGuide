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
    public class WayOfTourRepository : IWayOfTourRepository
    {
        private readonly TravelGuideDbContext _context;

        public WayOfTourRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<WayOfTour> Create(WayOfTour wayOfTour)
        {
            await _context.WayOfTours.AddAsync(wayOfTour);
            await _context.SaveChangesAsync();
            return wayOfTour;
        }

        public async Task Delete(WayOfTour wayOfTour)
        {
            _context.WayOfTours.Remove(wayOfTour);
            await _context.SaveChangesAsync();
        }

        public async Task<WayOfTour> Get(int id)
        {
            return await _context.WayOfTours.FindAsync(id);
        }

        public async Task<IEnumerable<WayOfTour>> GetAll()
        {
            return await _context.WayOfTours.ToListAsync();
        }

        public async Task<WayOfTour> Update(WayOfTour wayOfTour)
        {
            _context.WayOfTours.Update(wayOfTour);
            await _context.SaveChangesAsync();
            return wayOfTour;
        }
        public async Task<IEnumerable<WayOfTour>> GetByWayId(int wayId)
        {
            return await _context.WayOfTours
                                 .Where(wt => wt.WayId == wayId)
                                 .ToListAsync();
        }
    }
}
