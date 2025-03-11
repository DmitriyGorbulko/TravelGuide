using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("way_of_atraction")]
    public class WayOfAttraction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("way_id")]
        public int WayId { get; set; }

        public Way? Way { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("town")]
        public string Town { get; set; }
    }
}
