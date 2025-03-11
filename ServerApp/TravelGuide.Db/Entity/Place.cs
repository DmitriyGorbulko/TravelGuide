using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [Column("type_place_id")]
        public int TypePlaceId { get; set; }

        [JsonIgnore]
        public TypePlace? TypePlace { get; set; }

        public List<Review>? Reviews { get; }

        public List<TagOfPlace>? TagOfPlaces { get; }
    }
}
