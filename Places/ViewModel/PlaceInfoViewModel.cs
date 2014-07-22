using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class PlaceInfoViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        public PlaceInfoViewModel(GooglePlacesApi.PlaceInfo placeInfo, string distance, string priceLevel, bool openNow)
        {
            this.placeInfo = placeInfo;
            this.distance = distance;
            this.priceLevel = priceLevel;
            this.openNow = openNow;
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
