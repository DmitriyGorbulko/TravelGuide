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
    public class WayRepository : IWayRepository
    {
        private readonly TravelGuideDbContext _context;

        public WayRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<Way> Creare(Way way)
        {
            await _context.Ways.AddAsync(way);
            await _context.SaveChangesAsync();
            return way;
        }

        public async Task Delete(int id)
        {
            var way = await _context.Ways
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            _context.Ways.Remove(way);
            await _context.SaveChangesAsync();
        }

        public async Task<Way> Get(int id)
        {
            return await _context.Ways.FindAsync(id);
        }

        public async Task<IEnumerable<Way>> GetAll()
        {
            return await _context.Ways.ToListAsync();
        }

        public async Task<Way> Update(Way way)
        {
            var wayUpdate = await Get(way.Id);
            wayUpdate.Title = way.Title;
            wayUpdate.Description = way.Description;
            await _context.SaveChangesAsync();
            return wayUpdate;
        }
    }
}
