using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PlaceId { get; set; }
        public Place? Place { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
