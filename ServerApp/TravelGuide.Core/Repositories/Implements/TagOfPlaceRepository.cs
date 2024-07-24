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
    public class TagOfPlaceRepository : ITagOfPlaceRepository
    {
        private readonly TravelGuideDbContext _context;

        public TagOfPlaceRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<TagOfPlace> Create(TagOfPlace tagOfPlace)
        {
            await _context.TagOfPlaces.AddAsync(tagOfPlace);
            await _context.SaveChangesAsync();
            return tagOfPlace;
        }

        public async Task Delete(int id)
        {
            var tagOfPlaceDelete = await _context.TagOfPlaces.FindAsync(id);
            _context.TagOfPlaces.Remove(tagOfPlaceDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<TagOfPlace> Get(int id)
        {
            return await _context.TagOfPlaces.FindAsync(id);
        }

        public async Task<IEnumerable<TagOfPlace>> GetAll()
        {
            return await _context.TagOfPlaces.ToListAsync();
        }

        public async Task<TagOfPlace> Update(TagOfPlace tagOfPlace)
        {
            var tagOfPlaceUpdate = await _context.TagOfPlaces.FindAsync(tagOfPlace.Id);

            tagOfPlaceUpdate.TagId = tagOfPlace.TagId;
            tagOfPlaceUpdate.PlaceId = tagOfPlace.PlaceId;

            await _context.SaveChangesAsync();
            return tagOfPlaceUpdate;
        }
    }
}
