using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public abstract class PlaceController : NotifyPropertyBase
    {
        protected string key;
        protected string sensor;
        protected string language;
        protected const string api = @"https://maps.googleapis.com/maps/api/place/";
        protected HttpClient httpClient;

        public PlaceController(string key, string sensor, string language)
        {
            this.key = key;
            this.sensor = sensor;
            this.language = language;
            this.httpClient = new HttpClient();
        }
    }
}
