using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Models.Models
{
    public class Guide
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TownId { get; set; }
        public string Description { get; set; }
        public string TelegramUsername { get; set; }
    }
}
