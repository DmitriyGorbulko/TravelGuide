using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    [Table("way_of_guide")]
    public class WayOfGuide
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("way_id")]
        public int WayId { get; set; }

        public Way? Way { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("town")]
        public string Town { get; set; }

        [Column("telegram_username")]
        public string TelegramUsername { get; set; }
    }
}
