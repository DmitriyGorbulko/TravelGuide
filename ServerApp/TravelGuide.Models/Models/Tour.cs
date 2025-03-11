using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Models.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TownId { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
    }
}
