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

        public NerbySimplySearchViewModel(GooglePlacesApi.Type selectType)
        {
            this.selectType = selectType;
        }

        public void Navigation(Action navigationAction)
        {
            navigationAction();
        }

        public async Task<bool> GetData(Action geoLocationError)
        {
            IconStatus = "/Assets/UserLocation.png";

            GooglePlacesApi.GeoLocationController geolocationController = new GooglePlacesApi.GeoLocationController();

            GooglePlacesApi.Location location = new GooglePlacesApi.Location();

            try
            {
                location = await geolocationController.GetLocation();
       
            }
            catch
            {
                geoLocationError();
                return false;
            }

            IconStatus = "/Assets/SearchPlaces.png";

            GooglePlacesApi.NearbySearchController nerbySearch = new GooglePlacesApi.NearbySearchController(App.GoogleApiKeyTable.GetKey(), GooglePlacesApi.Sensor.TRUE, App.LanguageController.GetGooglePlacesLanguage(), "500", location.ApiFormat, true, "", "", selectType.Key, "", "");

            await nerbySearch.GetPlaces();

            return true;

     
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
