

using Microsoft.EntityFrameworkCore;
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Way> Get(int id)
        {
            return await _context.Ways.FindAsync(id);
        }

        public async Task<IEnumerable<Way>> GetAll()
        {

            return await _context.Ways.ToListAsync();
        }

        public async Task<IEnumerable<Way>> GetByUserId(int id)
        {
            var wayList = _context.Ways;
            var response = await wayList.Where(x => x.UserId == id).ToListAsync();
            return response;
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
