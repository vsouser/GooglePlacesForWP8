using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public abstract class PlacesController : NotifyPropertyBase
    {
        protected string api;
        protected string key;
        protected string sensor;
        protected string language;
        protected bool openNow;
        protected string minprice;
        protected string maxprice;
        protected HttpClient httpClient;

        public PlacesController(string key, string sensor, string language, bool openNow, string minprice = "", string maxprice = "", string api = @"https://maps.googleapis.com/maps/api/place/")
        {
            this.key = key;
            this.sensor = sensor;
            this.language = language;
            this.openNow = openNow;
            this.minprice = minprice;
            this.maxprice = maxprice;
            this.api = api;
            this.httpClient = new HttpClient();
        }

        public string Laguage
        {
            get
            {
                return language;
            }
        }

        protected void AddRangePlaces(JObject jObject, ObservableCollection<Place> Places)
        {
            List<Place> apiPlace = ParseJson(jObject);
            for (int i = 0; i < apiPlace.Count; i++)
            {
                Places.Add(apiPlace[i]);
            }
        }

        protected bool HasField(JObject jObject, string value)
        {
            if (jObject[value] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected List<Place> ParseJson(JObject jObject)
        {
            var results = jObject["results"].ToString();
            return JsonConvert.DeserializeObject<List<Place>>(results, new PlaceConverter());
        }
    }
}
