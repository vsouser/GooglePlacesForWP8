using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class TextSearchViewModel : BaseSearchViewModel
    {
        private string query;
        private string radius;
        private string types;


        public TextSearchViewModel(string query, string radius, string types = "")
        {
            this.query = query;
            this.radius = radius;
            this.types = types;
        }

        public override async Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction, Action apiErrorAction, Action queryLimitErrorAction)
        {
            IconStatus = "/Assets/UserLocation.png";

            GooglePlacesApi.GeoLocationController geolocationController = new GooglePlacesApi.GeoLocationController();

            try
            {
                Location = await geolocationController.GetLocation();

            }
            catch (Exception ex)
            {

                geoLocationError();
            }

            IconStatus = "/Assets/SearchPlaces.png";

            try
            {

                SearchController = new GooglePlacesApi.TextSearchController(query, App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, radius, Location.ApiFormat, App.LanguageController.GetGooglePlacesLanguage(), false, "", "", types);
                
                await SearchController.GetPlaces();

                compliteAction();
            }
            catch (GooglePlacesApi.SearchPlacesException ex)
            {
                if (ex.Name == GooglePlacesApi.Status.ZERO_RESULTS)
                {
                    zeroResulAction();
                }
                if (ex.Name == GooglePlacesApi.Status.INVALID_REQUEST)
                {
                    apiErrorAction();
                }
                if (ex.Name == GooglePlacesApi.Status.OVER_QUERY_LIMIT)
                {
                    App.GoogleApiKeyTable.RemoveKey();
                    queryLimitErrorAction();
                }
                if (ex.Name == GooglePlacesApi.Status.REQUEST_DENIED)
                {
                    apiErrorAction();
                }
            }
            catch (NullReferenceException)
            {
                geoLocationError();
            }
        }



    }
}
