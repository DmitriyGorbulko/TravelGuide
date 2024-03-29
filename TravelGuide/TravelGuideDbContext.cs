using Microsoft.EntityFrameworkCore;
using TravelGuide.Entity;

namespace TravelGuide
{
    public class TravelGuideDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public TravelGuideDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
