using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Db.Entity;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Db;

namespace TravelGuide.Core.Repositories.Implements
{
    public class WayOfAttractionRepository : IWayOfAttractionRepository
    {
        private readonly TravelGuideDbContext _context;

        public WayOfAttractionRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<WayOfAttraction> Create(WayOfAttraction wayOfAttraction)
        {
            await _context.WayOfAttractions.AddAsync(wayOfAttraction);
            await _context.SaveChangesAsync();
            return wayOfAttraction;
        }

        public async Task Delete(WayOfAttraction wayOfAttraction)
        {
            _context.WayOfAttractions.Remove(wayOfAttraction);
            await _context.SaveChangesAsync();
        }

        public async Task<WayOfAttraction> Get(int id)
        {
            return await _context.WayOfAttractions.FindAsync(id);
        }

        public async Task<IEnumerable<WayOfAttraction>> GetAll()
        {
            return await _context.WayOfAttractions.ToListAsync();
        }

        public async Task<WayOfAttraction> Update(WayOfAttraction wayOfAttraction)
        {
            _context.WayOfAttractions.Update(wayOfAttraction);
            await _context.SaveChangesAsync();
            return wayOfAttraction;
        }

        public async Task<IEnumerable<WayOfAttraction>> GetByWayId(int wayId)
        {
            return await _context.WayOfAttractions
                                 .Where(w => w.WayId == wayId)
                                 .ToListAsync();
        }
    }
}
