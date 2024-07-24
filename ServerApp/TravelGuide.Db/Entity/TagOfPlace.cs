using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("tag_of_place")]
    public class TagOfPlace
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("place_id")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
