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

        [Column("latitude")]
        public string Latitude { get; set; }

        [Column("longitude")]
        public string Longitude { get; set; }

        [Column("way_id")]
        public int WayId { get; set; }

        public Way? Way { get; set; }
    }
}
