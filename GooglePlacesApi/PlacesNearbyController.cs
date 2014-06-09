using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    /// <summary>
    /// 
    /// </summary>
    public class PlacesNearbyController : PlacesController
    {
        private string location;
        private string radius;

        public PlacesNearbyController(string key, string sensor, string output, string location, string radius) 
            : base(key, sensor,  output)
        {
            this.location = location;
            this.location = radius;
        }


        

    }
}
