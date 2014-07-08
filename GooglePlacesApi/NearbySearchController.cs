using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    /// <summary>
    /// 
    /// </summary>
    public class NearbySearchController : SearchPlacesController, IPlacesController
    {
        private string keyword;
        private string name;
        private string rankby;

        public NearbySearchController(string key, string sensor, string language, string radius, string location, bool openNow, string minprice, string maxprice, string types, string keyword, string name, string rankby = "prominence")
            : base(key, sensor, language, radius, location, openNow, minprice, maxprice, types)
        {
            this.location = location;
            this.types = types;
            this.radius = radius;
            this.keyword = keyword;
            this.name = name;
            this.rankby = rankby;
        }

        public override async Task<ObservableCollection<Place>> GetPlaces()
        {
            string url = String.Empty;
            if (String.IsNullOrEmpty(NextPageToken) == true)
            {
                if (rankby == Rankby.DISTANCE)
                {
                    url = api + "nearbysearch/" + "json" + "?" + "location=" + location + "&sensor=" + sensor + "&rankby=" + rankby + "&opennow=" + openNow.ToString();
                }
                else
                {
                    url = api + "nearbysearch/" + "json" + "?" + "location=" + location + "&radius=" + radius + "&sensor=" + sensor + "&rankby=" + rankby + "&opennow=" + openNow.ToString();
                }
                if (String.IsNullOrEmpty(minprice) == false)
                {
                    url += "&minprice=" + minprice;
                }
                if (String.IsNullOrEmpty(maxprice) == false)
                {
                    url += "&maxprice=" + maxprice;
                }
                if (String.IsNullOrEmpty(keyword) == false)
                {
                    url += "&keyword=" + keyword;
                }
                if (String.IsNullOrEmpty(name) == false)
                {
                    url += "&name=" + name;
                }
                if (String.IsNullOrEmpty(types) == false)
                {
                    url += "&types=" + types;
                }
                if (String.IsNullOrEmpty(language) == false)
                {
                    url += "&language=" + language;
                }
                url += "&key=" + key;
            }
            else
            {
                url = api + "nearbysearch/" + "json" + "?" + "pagetoken=" + NextPageToken + "&sensor=" + sensor + "&key=" + key;
            }

            await GetData(url);

            GetToken();

            var places = GetResult(jObject, searchStatus);

            foreach (Place plac in places)
            {
                Places.Add(plac);
            }

            return Places;
        }
    }
}
