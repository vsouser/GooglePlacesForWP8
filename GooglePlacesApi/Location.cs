﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Location(double latitude, double longitude)
        {
            this.Lat = latitude;
            this.Lng = longitude;
        }

        public string ApiFormat
        {
            get { return this.Lat.ToString(CultureInfo.InvariantCulture) + "," + this.Lng.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
