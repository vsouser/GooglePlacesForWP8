using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    abstract class PlacesController
    {
        protected string key;
        protected string sensor;
        protected string output;

        public PlacesController(string key, string sensor, string output)
        {
            this.key = key;
            this.sensor = sensor;
            this.output = output;
        }
    }
}
