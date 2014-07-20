using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public abstract class BaseSearchViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        protected string iconStatus;
        protected SearchPlacesController nerbySearch;
        private GooglePlacesApi.Location location;

        public abstract Task GetData(Action geoLocationError, Action compliteAction, Action zeroResulAction, Action apiErrorAction);

        public void Navigation(Action navigationAction)
        {
            navigationAction();
        }

        public SearchPlacesController SearchController
        {
            get
            {
                return nerbySearch;
            }
            set
            {
                SetProperty<SearchPlacesController>(ref nerbySearch, value);
            }
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
