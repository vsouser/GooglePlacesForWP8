using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class PlaceInfoViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        public PlaceInfoViewModel(GooglePlacesApi.PlaceInfo placeInfo)
        {
            this.placeInfo = placeInfo;
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
