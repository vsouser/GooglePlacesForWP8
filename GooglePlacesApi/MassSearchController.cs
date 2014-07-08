using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class MassSearchController : SearchPlacesController, IPlacesController
    {
        private string keyword;
        private string name;

        public MassSearchController(string key, string sensor, string radius, string location, string types, bool opennow = false, string minprice = "", string maxprice = "", string keyword = "", string name = "")
            : base(key, sensor, "", radius, location, opennow, minprice, maxprice, types)
        {
            this.keyword = keyword;
            this.name = name;
        }

        public override async Task<ObservableCollection<Place>> GetPlaces()
        {
            string url = String.Empty;

            url += api + "radarsearch/" + "json" + "?" + "location=" + location + "&radius=" + radius + "&sensor=" + sensor + "&opennow=" + openNow;

            if (String.IsNullOrEmpty(minprice) == false)
            {
                url += "&minprice=" + minprice;
            }
            if (String.IsNullOrEmpty(maxprice) == false)
            {
                url += "&maxprice=" + maxprice;
            }
            if (String.IsNullOrEmpty(name) == false)
            {
                url += "&name=" + name;
            }
            if (String.IsNullOrEmpty(keyword) == false)
            {
                url += "&keyword=" + keyword;
            }
            if (String.IsNullOrEmpty(types) == false)
            {
                url += "&types=" + types;
            }


            url += "&keys=" + key;

            await GetData(url);

            GetToken();

            Places = GetResult(jObject, searchStatus);

            return Places;

        }
    }
}
