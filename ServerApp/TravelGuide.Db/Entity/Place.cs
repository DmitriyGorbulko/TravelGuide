using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PointId { get; set; }
        
        public Point? Point { get; set; }
    }
}
