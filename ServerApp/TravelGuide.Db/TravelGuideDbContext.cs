using Microsoft.EntityFrameworkCore;
using TravelGuide.Db.Entity;

namespace TravelGuide.Db
{
    public class TravelGuideDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Place> Places { get; set; }
        
        public TravelGuideDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
