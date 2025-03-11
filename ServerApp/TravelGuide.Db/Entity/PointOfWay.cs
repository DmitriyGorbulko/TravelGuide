using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("point_of_way")]
    public class PointOfWay
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("way_id")]
        public int WayId { get; set; }

        public Way? Way { get; set; }

        [Column("place_id")]
        public int PlaceId { get; set; }

        public Place? Place { get; set; }
    }
}
