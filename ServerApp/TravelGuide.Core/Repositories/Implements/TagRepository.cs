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
    public class TagRepository : ITagRepository
    {
        private readonly TravelGuideDbContext _context;

        public TagRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Create(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task Delete(int id)
        {
            var tagDelete = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tagDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Tag> Get(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> Update(Tag tag)
        {
            var tagUpdate = await _context.Tags.FindAsync(tag.Id);
            tagUpdate.Title = tag.Title;
            tagUpdate.Description = tag.Description;
            tagUpdate.IsPrivate = tag.IsPrivate;
            await _context.SaveChangesAsync();
            return tagUpdate;
        }
    }
}
