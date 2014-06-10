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
    public class PlacesNearbyController : PlacesController, IPlacesController
    {
        private string location;
        private string radius;
        private string types;

        public PlacesNearbyController(string key, string sensor, string output, string location, string radius, string language = "", string types = "", string api = @"https://maps.googleapis.com/maps/api/place/") 
            : base(key, sensor, output, language, api)
        {
            this.location = location;
            this.types = types;
            this.radius = radius;
        }


        public async Task<Places> GetPlaces()
        {
            string url = api + "nearbysearch/" + output + "?" + "location=" + location + "&radius=" + radius + "&sensor=" + sensor;
            if (String.IsNullOrEmpty(types) == false)
            {
                url += "&types=" + types;
            }
            if (String.IsNullOrEmpty(language) == false)
            {
                url += "&language=" + language; 
            }

            url += "&key=" + key; 

            string result = await httpClient.GetStringAsync(url);
            return new Places() { Format = output, Result = result };
        }
    }
}
