using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class PointOfWay
    {
        public int Id { get; set; }

        public int PointId { get; set; }

        public Point? Point { get; set; }

        public int WayId { get; set; }

        public Way? Way { get; set; }
    }
}
