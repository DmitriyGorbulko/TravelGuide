using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Models.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public string? Town { get; set; }
        public string TypeAttraction { get; set; }
    }
}
