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
    public class FavoriteTagRepository : IFavoriteTagRepository
    {
        private readonly TravelGuideDbContext _context;

        public FavoriteTagRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<FavoriteTag> Create(FavoriteTag favoriteTag)
        {
            await _context.FavoriteTags.AddAsync(favoriteTag);
            await _context.SaveChangesAsync();
            return favoriteTag;
        }

        public async Task Delete(int id)
        {
            var favoriteTag = await _context.FavoriteTags.FindAsync(id);
            _context.FavoriteTags.Remove(favoriteTag);
            await _context.SaveChangesAsync();
        }

        public async Task<FavoriteTag> Get(int id)
        {
            return await _context.FavoriteTags.FindAsync(id);
        }

        public async Task<IEnumerable<FavoriteTag>> GetAll()
        {
            return await _context.FavoriteTags.ToListAsync();
        }

        public async Task<FavoriteTag> Update(FavoriteTag favoriteTag)
        {
            var favoriteTagUpdate = await _context.FavoriteTags.FindAsync(favoriteTag.Id);
            favoriteTagUpdate.TagId = favoriteTag.TagId;
            favoriteTagUpdate.UserId = favoriteTag.UserId;

            await _context.SaveChangesAsync();
            return favoriteTagUpdate;
        }
    }
}
