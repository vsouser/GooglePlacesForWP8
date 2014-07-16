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


        public TextSearchViewModel(string query, string radius)
        {
            this.query = query;
            this.radius = radius;
        }

        public override async Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction)
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

               // SearchController = new GooglePlacesApi.NearbySearchController(App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, App.LanguageController.GetGooglePlacesLanguage(), "1000", location.ApiFormat, true, "", "", selectType.Key, "", "");
                SearchController = new GooglePlacesApi.TextSearchController(query, App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, radius, Location.ApiFormat, App.LanguageController.GetGooglePlacesLanguage(), true, "", "");
                
                await SearchController.GetPlaces();

                compliteAction();
            }
            catch (GooglePlacesApi.SearchPlacesException ex)
            {
                if (ex.Name == GooglePlacesApi.Status.ZERO_RESULTS)
                {
                    zeroResulAction();
                }
            }
            catch (NullReferenceException)
            {
                geoLocationError();
            }
        }



    }
}
