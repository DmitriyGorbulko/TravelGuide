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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Place> Get(int id)
        {
            return await _context.Places.FindAsync(id);
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _context.Places.ToListAsync();
        }

#warning
        public async Task<Place> Update(Place place)
        {
            var placeUpdate = await _context.Places.FindAsync(place.Id);
            /*placeUpdate.Name = place.Name;
            placeUpdate.PointId = place.PointId;*/
            await _context.SaveChangesAsync();
            return placeUpdate;
        }
    }
}
