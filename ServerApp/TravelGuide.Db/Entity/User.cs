using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Db.Entity
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        public List<FavoriteTag>? FavoriteTags { get; }

        public List<Review>? Reviews { get; }

        public List<Tag>? Tags { get; }

        public List<Way>? Ways { get; }
    }
}
