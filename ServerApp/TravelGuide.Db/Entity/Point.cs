using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class Point
    {

        public int Id { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public List<Place>? Places { get; }

        public List<PointOfWay>? PointOfWays { get; set; }
    }
}
