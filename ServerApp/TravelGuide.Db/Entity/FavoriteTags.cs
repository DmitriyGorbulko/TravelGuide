using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("favorite_tag")]
    public class FavoriteTag
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
