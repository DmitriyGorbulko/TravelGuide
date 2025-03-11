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
    public class WayOfGuideRepository : IWayOfGuideRepository
    {
        TravelGuideDbContext _context;

        public WayOfGuideRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<WayOfGuide> Create(WayOfGuide wayOfGuide)
        {
            await _context.WayOfGuides.AddAsync(wayOfGuide);
            await _context.SaveChangesAsync();
            return wayOfGuide;
        }

        public async Task Delete(WayOfGuide wayOfGuide)
        {
            _context.WayOfGuides.Remove(wayOfGuide);
            await _context.SaveChangesAsync();
        }

        public async Task<WayOfGuide> Get(int id)
        {
            return await _context.WayOfGuides.FindAsync(id);
        }

        public async Task<IEnumerable<WayOfGuide>> GetAll()
        {
            return await _context.WayOfGuides.ToListAsync();
        }

        public async Task<WayOfGuide> Update(WayOfGuide wayOfGuide)
        {
            _context.WayOfGuides.Update(wayOfGuide);
            await _context.SaveChangesAsync();
            return wayOfGuide;
        }

        public async Task<IEnumerable<WayOfGuide>> GetByWayId(int wayId)
        {
            return await _context.WayOfGuides
                                 .Where(wg => wg.WayId == wayId)
                                 .ToListAsync();
        }
    }
}
