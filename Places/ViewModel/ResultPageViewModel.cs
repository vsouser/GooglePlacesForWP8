using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Places.ViewModel
{
    public class ResultPageViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        private SearchPlacesController searchPlacesController;
        private GeoCoordinate userGeoCoordinate;

        public SearchPlacesController SearchPlacesController
        {
            get
            {
                return searchPlacesController;
            }
            set
            {
                SetProperty<SearchPlacesController>(ref searchPlacesController, value);
            }
        }

        public GeoCoordinate UserGeoCoordinate 
        {
            get
            {
                return userGeoCoordinate;
            }
            set
            {
                SetProperty<GeoCoordinate>(ref userGeoCoordinate, value);
            }
                
        }

        public ResultPageViewModel(SearchPlacesController searchPlacesController, GooglePlacesApi.Location location)
        {
            this.searchPlacesController = searchPlacesController;
            UserGeoCoordinate = new GeoCoordinate() { Latitude = location.Lat, Longitude = location.Lng};          
        }
    }
}
