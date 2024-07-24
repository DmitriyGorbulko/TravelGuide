using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("review")]
    public class Review
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Column("place_id")]
        public int PlaceId { get; set; }
        public Place? Place { get; set; }
    }
}