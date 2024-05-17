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
        private readonly TravelGuideDbContext _contex;

        public WayRepository(TravelGuideDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Way> Creare(Way way)
        {
            await _contex.Ways.AddAsync(way);
            await _contex.SaveChangesAsync();
            return way;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Way> Get(int id)
        {
            return await _contex.Ways.FindAsync(id);
        }

        public async Task<IEnumerable<Way>> GetAll()
        {
            return await _contex.Ways.ToListAsync();
        }

        public async Task<Way> Update(Way way)
        {
            var wayUpdate = await Get(way.Id);
            wayUpdate.Title = way.Title;
            wayUpdate.Description = way.Description;
            await _contex.SaveChangesAsync();
            return wayUpdate;
        }
    }
}
