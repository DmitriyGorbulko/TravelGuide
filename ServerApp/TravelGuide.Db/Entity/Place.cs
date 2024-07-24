using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("place")]
    public class Place
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("latitude")]
        public string Latitude { get; set; }

        [Column("longitude")]
        public string Longitude { get; set; }

        [Column("type_place_id")]
        public int TypePlaceId { get; set; }
        public TypePlace TypePlace { get; set; }

        public List<Review>? Reviews { get; }

        public List<TagOfPlace>? TagOfPlaces { get; }
    }
}
