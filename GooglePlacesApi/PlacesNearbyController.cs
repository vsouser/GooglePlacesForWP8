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
    public class PlacesNearbyController : PlacesController, IPlacesController
    {
        private string location;
        private string radius;
        private string types;
        private string keyword;
        private string name;
        private string rankby;

        private string searchStatus;
        private string nextPageToken;
        private bool isNextPage = true;
        private string result = String.Empty;
        private JObject jObject;
        private ObservableCollection<Place> places = new ObservableCollection<Place>();


        public PlacesNearbyController(string key, string sensor, string output, string location, string radius, bool openNow, string rankby = "prominence", string minprice = "", string maxprice = "", string language = "", string types = "", string keyword = "", string name = "", string api = @"https://maps.googleapis.com/maps/api/place/")
            : base(key, sensor, output, language, openNow, minprice, maxprice, api)
        {
            this.location = location;
            this.types = types;
            this.radius = radius;
            this.keyword = keyword;
            this.name = name;
            this.rankby = rankby;
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

        public async Task<ObservableCollection<Place>> GetPlaces()
        {
            string url = String.Empty;

            if (String.IsNullOrEmpty(NextPageToken) == true)
            {
                if (rankby == Rankby.DISTANCE)
                {
                    url = api + "nearbysearch/" + output + "?" + "location=" + location + "&sensor=" + sensor + "&rankby=" + rankby + "&opennow=" + openNow.ToString();
                }
                else
                {
                    url = api + "nearbysearch/" + output + "?" + "location=" + location + "&radius=" + radius + "&sensor=" + sensor + "&rankby=" + rankby + "&opennow=" + openNow.ToString();
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
                url = api + "nearbysearch/" + output + "?" + "pagetoken=" + NextPageToken + "&sensor=" + sensor + "&key=" + key;
            }

            if (isNextPage == true)
            {
                Result = await httpClient.GetStringAsync(url);
            }
            else
            {
                throw new SearchPlacesException("All the places on this request is already loaded", Status.OK);
            }

            if (this.output == GooglePlacesApi.Output.JSON)
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
                        AddRangePlaces(jObject);
                        return Places;
                    default:
                        AddRangePlaces(jObject);
                        return Places;
                }
            }
            else
            {
                string xml = Result;
                HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(xml);

                var xmlDocument = document.DocumentNode;
                var rootCollection = xmlDocument.ChildNodes;
                for (int i = 0; i < rootCollection.Count; i++)
                {
                    if (rootCollection[i].Name == "PlaceSearchResponse")
                    {
                        HtmlNode node = rootCollection[i];

                        var placesNode = node.ChildNodes;

                        for (int j = 0; j < placesNode.Count; j++)
                        {
                            if (placesNode[j].Name == "status")
                            {
                                ResultStatus = placesNode[j].InnerText;
                            }
                            if (placesNode[j].Name == "next_page_token")
                            {
                                NextPageToken = placesNode[j].InnerText;
                            }
            
                        }
                    }
                
                }
                    //AddRangePlaces(jObject);
                return Places;
            }
        }

        private void AddRangePlaces(JObject jObject)
        {
            List<Place> apiPlace = ParseJson(jObject);
            for (int i = 0; i < apiPlace.Count; i++)
            {
                Places.Add(apiPlace[i]);
            }
        }

        private bool HasField(JObject jObject, string value)
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

        private List<Place> ParseJson(JObject jObject)
        {
            var results = jObject["results"].ToString();
            return JsonConvert.DeserializeObject<List<Place>>(results, new PlaceConverter());
        }
    }
}
