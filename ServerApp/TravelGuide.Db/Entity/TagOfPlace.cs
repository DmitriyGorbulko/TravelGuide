using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class TagOfPlace
    {
        public int Id { get; set; }

        public int PlaceId { get; set; }
        public Place? Place { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
