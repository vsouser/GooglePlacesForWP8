using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string sensor;
        private string extensions;
        private string language;
        private string api;
        private string result;
        private string resultStatus;
        protected HttpClient httpClient;
        protected JObject jObject;
        
        public PlaceInfoController(string key, string references, string sensor, string extensions = "", string language = "", string api = "https://maps.googleapis.com/maps/api/place/")
        {
            this.key = key;
            this.references = references;
            this.sensor = sensor;
            this.extensions = extensions;
            this.language = language;
            this.api = api;
            this.httpClient = new HttpClient();
        }




        public async Task<PlaceInfo> GetPlaceInfo()
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

            url += "&key=" + key;

            await GetData(url);

            GetToken();

            return GetResult(jObject, resultStatus);
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


        protected void GetToken()
        {
            try
            {
                jObject = JObject.Parse(Result);

                if (HasField(jObject, "status") == true)
                {
                    ResultStatus = jObject["status"].ToString();
                }
                else
                {
                    throw new SearchPlacesException("Error parse json data", Status.INVALID_REQUEST);
                }
            }
            catch
            {
                throw new SearchPlacesException("Error parse json data", Status.INVALID_REQUEST);
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

        protected PlaceInfo GetResult(JObject jObject, string searchStatus)
        {
            switch (searchStatus)
            {
                case Status.REQUEST_DENIED:
                    throw new SearchPlacesException(jObject["error_message"].ToString(), Status.REQUEST_DENIED);
                case Status.ZERO_RESULTS:
                    throw new SearchPlacesException("Results not found", Status.ZERO_RESULTS);
                case Status.INVALID_REQUEST:
                    throw new SearchPlacesException("Required parameter is missing", Status.INVALID_REQUEST);
                case Status.OVER_QUERY_LIMIT:
                    throw new SearchPlacesException("Quota is over", Status.OVER_QUERY_LIMIT);
                case Status.NOT_FOUND:
                    throw new SearchPlacesException("No specified location", Status.NOT_FOUND);
                case Status.UNKNOWN_ERROR:
                    throw new SearchPlacesException("Error on the server side", Status.UNKNOWN_ERROR);
                case Status.OK:
                    return ParsePlaces(jObject);
                default:
                    return ParsePlaces(jObject);
            }
        }


        protected PlaceInfo ParsePlaces(JObject jObject)
        {
            try
            {
                return ParseJson(jObject);
            }
            catch
            {
                throw new SearchPlacesException("Error parse json data", Status.INVALID_REQUEST);
            }
        }


        protected PlaceInfo ParseJson(JObject jObject)
        {
            var results = jObject["result"].ToString();
            return JsonConvert.DeserializeObject<PlaceInfo>(results, new PlaceInfoConverter());
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

        public string ResultStatus
        {
            get
            {
                return resultStatus;
            }
            set
            {
                SetProperty<string>(ref resultStatus, value);
            }
        }

    }
}
