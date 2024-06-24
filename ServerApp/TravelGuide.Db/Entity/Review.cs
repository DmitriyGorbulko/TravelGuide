using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Utilites.Enums;

namespace TravelGuide.Db.Entity
{
    public class Review
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public Rating Rating { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int PlaceId { get; set; }
        public Place? Place { get; set; }
    }
}
