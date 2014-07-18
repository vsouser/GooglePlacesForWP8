using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class NerbySimplySearchViewModel : BaseSearchViewModel
    {
        private GooglePlacesApi.Type selectType;
        

        public NerbySimplySearchViewModel(GooglePlacesApi.Type selectType)
        {
            this.selectType = selectType;
        }

        public override async Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction)
        {
            IconStatus = "/Assets/UserLocation.png";

            GooglePlacesApi.GeoLocationController geolocationController = new GooglePlacesApi.GeoLocationController();

            try
            {
                Location = await geolocationController.GetLocation();
       
            }
            catch(Exception ex)
            {
        
                geoLocationError();
            }

            IconStatus = "/Assets/SearchPlaces.png";

            try
            {

                SearchController = new GooglePlacesApi.NearbySearchController(App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, App.LanguageController.GetGooglePlacesLanguage(), "1000", Location.ApiFormat, false, "", "", selectType.Key, "", "");

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
