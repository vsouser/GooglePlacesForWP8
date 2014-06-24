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
        protected string types;
        protected string radius;
        protected string location;

        protected bool isNextPage = true;
        protected string nextPageToken;
        protected string searchStatus;
        protected string result = String.Empty;
        protected JObject jObject;
        protected ObservableCollection<Place> places = new ObservableCollection<Place>();

        public SearchPlacesController(string key, string sensor, string language, string radius, string location, bool openNow, string minprice, string maxprice, string types)
            : base(key, sensor, language)
        {
            this.radius = radius;
            this.location = location;
            this.openNow = openNow;
            this.minprice = minprice;
            this.maxprice = maxprice;
            this.types = types;
        }

        public bool IsNextPage
        {
            get
            {
                return isNextPage;
            }
            set
            {
                SetProperty<bool>(ref isNextPage, value);
            }
        }

        public string NextPageToken
        {
            get
            {
                return nextPageToken;
            }
            set
            {
                SetProperty<string>(ref nextPageToken, value);
            }
        }

        public string ResultStatus
        {
            get
            {
                return searchStatus;
            }
            set
            {
                SetProperty<string>(ref searchStatus, value);
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

        public ObservableCollection<Place> Places
        {
            get
            {
                return places;
            }
            set
            {
                SetProperty<ObservableCollection<Place>>(ref places, value);
            }
        }


        public string Laguage
        {
            get
            {
                return language;
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
                if (HasField(jObject, "next_page_token") == true)
                {
                    NextPageToken = jObject["next_page_token"].ToString();
                    IsNextPage = true;
                }
                else
                {
                    NextPageToken = String.Empty;
                    IsNextPage = false;
                }
            }
            catch
            {
                throw new SearchPlacesException("Error parse json data", Status.INVALID_REQUEST);
            }
        }

        protected async Task GetData(string url)
        {

            if (isNextPage == true)
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
            else
            {
                throw new SearchPlacesException("All the places on this request is already loaded", Status.OK);
            }
        }

        protected ObservableCollection<Place> GetResult(JObject jObject, string searchStatus)
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
                case Status.OK:
                    return ParsePlaces(jObject);
                default:
                    return ParsePlaces(jObject);
            }
        }

        protected ObservableCollection<Place> ParsePlaces(JObject jObject)
        {
            try
            {
                ObservableCollection<Place> places = new ObservableCollection<Place>();
                
                List<Place> apiPlace = ParseJson(jObject);
                
                for (int i = 0; i < apiPlace.Count; i++)
                {
                    places.Add(apiPlace[i]);
                }

                return places;
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

        protected List<Place> ParseJson(JObject jObject)
        {
            var results = jObject["results"].ToString();
            return JsonConvert.DeserializeObject<List<Place>>(results, new PlaceConverter());
        }
    }
}
