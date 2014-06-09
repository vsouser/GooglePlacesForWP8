using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Location
    {
        protected double latitude;
        protected double longitude;

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string ApiFormat
        {
            get { return this.latitude.ToString() + "," + this.longitude.ToString(); }
        }
    }
}
