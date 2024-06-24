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
    public class TypePlaceRepository : ITypePlaceRepository
    {
        private readonly TravelGuideDbContext _context;

        public TypePlaceRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<TypePlace> Create(TypePlace typePlace)
        {
            await _context.TypePlaces.AddAsync(typePlace);
            await _context.SaveChangesAsync();
            return typePlace;
        }

        public async Task Delete(int id)
        {
            var typePoint = await _context.TypePlaces.FindAsync(id);
            _context.TypePlaces.Remove(typePoint);
            await _context.SaveChangesAsync();
        }

        public async Task<TypePlace> Get(int id)
        {
            return await _context.TypePlaces.FindAsync(id);
        }

        public async Task<IEnumerable<TypePlace>> GetAll()
        {
            return await _context.TypePlaces.ToListAsync();
        }

        public async Task<TypePlace> Update(TypePlace typePlace)
        {
            var typePlaceUpdate = await _context.TypePlaces.FindAsync(typePlace.Id);
            typePlaceUpdate.Title = typePlace.Title;
            await _context.SaveChangesAsync();
            return typePlace;
        }
    }
}
