using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public abstract class PlacesController
    {
        protected string api;
        protected string key;
        protected string sensor;
        protected string output;
        protected string language;
        protected HttpClient httpClient;

        public PlacesController(string key, string sensor, string output, string language, string api = @"https://maps.googleapis.com/maps/api/place/")
        {
            this.key = key;
            this.sensor = sensor;
            this.output = output;
            this.language = language;
            this.api = api;
            this.httpClient = new HttpClient();
        }
    }
}
