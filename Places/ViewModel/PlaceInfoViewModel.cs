using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class PlaceInfoViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        public PlaceInfoViewModel(GooglePlacesApi.PlaceInfo placeInfo, string distance, string priceLevel, bool openNow, GeoCoordinate userLocation, GeoCoordinate placeLocation)
        {
            this.placeInfo = placeInfo;
            this.distance = distance;
            this.priceLevel = priceLevel;
            this.openNow = openNow;
            this.userLocation = userLocation;
            this.placeLocation = placeLocation;
        }

        public void InitData()
        {
            if (this.PlaceInfo.Reviews != null)
            {
                this.PlaceInfo.Reviews = this.PlaceInfo.Reviews.FindAll(pr => pr.Text != "");

                if (this.PlaceInfo.Reviews.Count > 0)
                {
                    RevewsVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    RevewsVisibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
            {
                RevewsVisibility = System.Windows.Visibility.Collapsed;
            }
        }

        private System.Windows.Visibility revewsVisibility;

        public System.Windows.Visibility RevewsVisibility
        {
            get
            {
                return revewsVisibility;
            }
            set
            {
                SetProperty<System.Windows.Visibility>(ref revewsVisibility, value);
            }
        }

        private GeoCoordinate userLocation;

        public GeoCoordinate UserLocation
        {
            get
            {
                return userLocation;
            }
            set
            {
                SetProperty<GeoCoordinate>(ref userLocation, value);
            }
        }

        private GeoCoordinate placeLocation;

        public GeoCoordinate PlaceLocation
        {
            get
            {
                return placeLocation;
            }
            set
            {
                SetProperty<GeoCoordinate>(ref placeLocation, value);
            }
        }

        private string distance;

        public string Distance
        {
            get
            {
                return distance;
            }
            set
            {
                SetProperty<string>(ref distance, value);
            }
        }

        private string priceLevel;

        public string PriceLevel
        {
            get
            {
                return priceLevel;
            }
            set
            {
                SetProperty<string>(ref priceLevel, value);
            }
        }

        private bool openNow;

        public bool OpenNow
        {
            get
            {
                return openNow;
            }
            set
            {
                SetProperty<bool>(ref openNow, value);
            }
        }
        


        private GooglePlacesApi.PlaceInfo placeInfo;

        public GooglePlacesApi.PlaceInfo PlaceInfo
        {
            get
            {
                return placeInfo;
            }
            set
            {
                SetProperty<GooglePlacesApi.PlaceInfo>(ref placeInfo, value);
            }
        }
    }
}
