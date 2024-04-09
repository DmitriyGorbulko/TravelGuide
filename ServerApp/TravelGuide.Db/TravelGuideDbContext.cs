using Microsoft.EntityFrameworkCore;
using TravelGuide.Db.Entity;

namespace TravelGuide.Db
{
    public class TravelGuideDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public TravelGuideDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
