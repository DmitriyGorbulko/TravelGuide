using Microsoft.EntityFrameworkCore;
using TravelGuide.Db.Entity;

namespace TravelGuide.Db
{
    public class TravelGuideDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<TypePlace> TypePlaces { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagOfPlace> TagOfPlaces { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<FavoritePlaceUser> FavoritePlaceUsers { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PointOfWay> PointOfWays { get; set; }


        public TravelGuideDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
