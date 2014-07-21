using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public abstract class BaseSearchPlacesViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        protected string iconStatus;

        protected PlaceInfoController placeInfoController;


        public abstract Task GetData(Action compliteAction, Action zeroResulAction, Action apiErrorAction);

        public void Navigation(Action navigationAction)
        {
            navigationAction();
        }

        public PlaceInfoController PlaceInfoController
        {
            get
            {
                return placeInfoController;
            }
            set
            {
                SetProperty<PlaceInfoController>(ref placeInfoController, value);
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
