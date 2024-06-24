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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly TravelGuideDbContext _context;

        public PlaceRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<Place> Create(Place place)
        {
            await _context.Places.AddAsync(place);
            await _context.SaveChangesAsync();
            return place;
        }

        public async Task Delete(int id)
        {
            var place = await _context.Places.FindAsync(id);
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }

        public async Task<Place> Get(int id)
        {
            return await _context.Places.FindAsync(id);
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<Place> Update(Place place)
        {
            var placeUpdate = await _context.Places
                .Where(p => p.Id == place.Id)
                .FirstOrDefaultAsync();
            placeUpdate.Title = place.Title;
            placeUpdate.TypePlaceId = place.TypePlaceId;
            await _context.SaveChangesAsync();
            return place;
        }
    }
}
