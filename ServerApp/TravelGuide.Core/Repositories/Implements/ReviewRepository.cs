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
    public class ReviewRepository : IReviewRepository
    {
        private readonly TravelGuideDbContext _context;

        public ReviewRepository(TravelGuideDbContext context)
        {
            _context = context;
        }

        public async Task<Review> Create(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task Delete(int id)
        {
            var reviewDelete = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviewDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Review> Get(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> Update(Review review)
        {
            var reviewUpdate = await _context.Reviews.FindAsync(review.Id);

            reviewUpdate.Description = review.Description;
            reviewUpdate.Rating = review.Rating;

            await _context.SaveChangesAsync();
            return reviewUpdate;
        }
    }
}
