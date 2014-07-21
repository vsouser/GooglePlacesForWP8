using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class PlaceInfoSearchViewModel : BaseSearchPlacesViewModel
    {
        private string references;
        private GooglePlacesApi.PlaceInfo placeInfo;

        public PlaceInfoSearchViewModel(string references)
        {
            this.references = references;
        }

        public override async Task GetData(Action compliteAction, Action zeroResulAction, Action apiErrorAction)
        {
            IconStatus = "/Assets/SearchPlaces.png";

            try
            {
                PlaceInfoController = new GooglePlacesApi.PlaceInfoController(App.GoogleApiKeyTable.GetKey(), references, GooglePlacesApi.Sensor.TRUE, "", App.LanguageController.GetGooglePlacesLanguage());

                PlaceInfo = await PlaceInfoController.GetPlaceInfo();

                compliteAction();
            }
            catch(GooglePlacesApi.SearchPlacesException ex)
            {
                if (ex.Name == GooglePlacesApi.Status.ZERO_RESULTS)
                {
                    zeroResulAction();
                }
                if (ex.Name == GooglePlacesApi.Status.INVALID_REQUEST)
                {
                    apiErrorAction();
                }
                if (ex.Name == GooglePlacesApi.Status.UNKNOWN_ERROR)
                {
                    apiErrorAction();
                }
                if (ex.Name == GooglePlacesApi.Status.REQUEST_DENIED)
                {
                    apiErrorAction();
                }
            }

        }


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
