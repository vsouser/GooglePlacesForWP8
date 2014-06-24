using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class TextSearchController : SearchPlacesController, IPlacesController
    {
        private string query;       

        public TextSearchController(string query, string key, string sensor, string radius = "", string location = "", string language = "", bool openNow = false, string minprice = "", string maxprice = "", string types = "")
            : base(key, sensor, language, radius, location, openNow, minprice, maxprice, types)
        {
            this.query = query;
        }

        public async Task<ObservableCollection<Place>> GetPlaces()
        {
            string url = String.Empty;
            if (String.IsNullOrEmpty(NextPageToken) == true)
            {
                url = api + "textsearch/" + "json" + "?" + "query=" + query + "&sensor=" + sensor + "&opennow=" + openNow;

                if (String.IsNullOrEmpty(radius) == false)
                {
                    url += "&radius=" + radius;
                }
                if(String.IsNullOrEmpty(location) == false)
                {
                    url += "&location=" + location;
                }
                if (String.IsNullOrEmpty(language) == false)
                {
                    url += "&language=" + language; 
                }
                if (String.IsNullOrEmpty(minprice) == false)
                {
                    url += "&minprice=" + minprice; 
                }
                if (String.IsNullOrEmpty(maxprice) == false)
                {
                    url += "&maxprice=" + maxprice;
                }
                if (String.IsNullOrEmpty(types) == false)
                {
                    url += "&types=" + types;
                 }

                url += "&key=" + key;
            }
            else
            {
                url += api + "textsearch/" + "json" + "?" + "pagetoken=" + NextPageToken + "&sensor=" + sensor + "&key=" + key;
            }

            await GetData(url);

            GetToken();

            Places = GetResult(jObject, searchStatus);

            return Places;
        }
    }
}
