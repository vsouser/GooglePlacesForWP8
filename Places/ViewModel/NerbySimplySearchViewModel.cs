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

        public override async Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction, Action apiErrorAction, Action queryLimitErrorAction)
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
                string key = App.GoogleApiKeyTable.GetKey();

                SearchController = new GooglePlacesApi.NearbySearchController(key, GooglePlacesApi.Sensor.TRUE, App.LanguageController.GetGooglePlacesLanguage(), "1000", Location.ApiFormat, false, "", "", selectType.Key, "", "");

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
