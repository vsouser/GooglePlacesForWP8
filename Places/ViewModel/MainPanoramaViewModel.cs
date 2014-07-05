using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class MainPanoramaViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        private ObservableCollection<GooglePlacesApi.Type> require;

        public MainPanoramaViewModel(List<GooglePlacesApi.Type> require)
        {
            this.require = new ObservableCollection<GooglePlacesApi.Type>(require);
        }

        public ObservableCollection<GooglePlacesApi.Type> Reqiure
        {
            get
            {
                return require;
            }
            set
            {
                SetProperty<ObservableCollection<GooglePlacesApi.Type>>(ref require, value);
            }
        }


        public void Exit(Action onExitCallback)
        {
            onExitCallback();
        }
    }
}
