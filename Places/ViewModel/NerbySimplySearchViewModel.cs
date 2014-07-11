using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class NerbySimplySearchViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        private string iconStatus;
        private GooglePlacesApi.Type selectType;
        private NearbySearchController nerbySearch;
        private GooglePlacesApi.Location location;

        public NerbySimplySearchViewModel(GooglePlacesApi.Type selectType)
        {
            this.selectType = selectType;
        }

        public void Navigation(Action navigationAction)
        {
            navigationAction();
        }

        public GooglePlacesApi.Location Location
        {
            get
            {
                return location;
            }
            set
            {
                SetProperty<GooglePlacesApi.Location>(ref location, value);
            }
        }

        public async Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction)
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

                NerbySearch = new GooglePlacesApi.NearbySearchController(App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, App.LanguageController.GetGooglePlacesLanguage(), "1000", location.ApiFormat, true, "", "", selectType.Key, "", "");

                await NerbySearch.GetPlaces();

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


        public NearbySearchController NerbySearch
        {
            get
            {
                return nerbySearch;
            }
            set
            {
                SetProperty<NearbySearchController>(ref nerbySearch, value);
            }
        }

        public string IconStatus
        {
            get
            {
                return iconStatus;
            }
            set
            {
                SetProperty<string>(ref iconStatus, value);
            }
        }
    }
}
