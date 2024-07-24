using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("tag")]
    public class Tag
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_private")]
        public bool IsPrivate { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<FavoriteTag>? FavoriteTag { get; }

        public List<TagOfPlace>? TagOfPlaces { get; }

    }
}
