using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("way")]
    public class Way
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<PointOfWay>? PointOfWays { get; }
    }

}
