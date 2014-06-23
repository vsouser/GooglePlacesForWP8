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
    public abstract class SearchPlacesController : PlaceController
    {
        protected bool openNow;
        protected string minprice;
        protected string maxprice;
        

        public SearchPlacesController(string key, string sensor, string language, bool openNow, string minprice, string maxprice)
            : base(key, sensor, language)
        {
            this.openNow = openNow;
            this.minprice = minprice;
            this.maxprice = maxprice;
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
