using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class PlaceInfoController : NotifyPropertyBase
    {
        private string key;
        private string references;
        private bool sensor;
        private string extensions;
        private string language;
        private string api;
        private string result;
        protected HttpClient httpClient;
        
        public PlaceInfoController(string key, string references, bool sensor, string extensions = "", string language = "", string api = "https://maps.googleapis.com/maps/api/place/")
        {
            this.key = key;
            this.references = references;
            this.sensor = sensor;
            this.extensions = extensions;
            this.language = language;
            this.api = api;
            this.httpClient = new HttpClient();
        }




        public async Task GetPlaceInfo()
        {
            string url = String.Empty;

            url += api + "details/json?" + "reference=" + references + "&sensor=" + sensor;

            if (String.IsNullOrEmpty(extensions) == false)
            {
                url += "&extensions=" + extensions;
            }
            if (String.IsNullOrEmpty(language) == false)
            {
                url += "&language=" + language;
            }

            url += url + "&key=" + key;

            await GetData(url);
        }


        protected async Task GetData(string url)
        {
            try
            {
                Result = await httpClient.GetStringAsync(url);
            }
            catch
            {
                throw new SearchPlacesException("No internet connection or server is not response", Status.INVALID_REQUEST);
            }
        }


        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                SetProperty<string>(ref result, value);
            }
        }

    }
}
