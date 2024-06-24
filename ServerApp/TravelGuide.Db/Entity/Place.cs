﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Db.Entity
{
    public class Place
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TypePlaceId { get; set; }
        public TypePlace? TypePlace { get; set; } 

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
