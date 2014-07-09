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
        private ObservableCollection<Radius> radius;


        public MainPanoramaViewModel(List<GooglePlacesApi.Type> require)
        {
            this.require = new ObservableCollection<GooglePlacesApi.Type>(require);
            this.radius = new ObservableCollection<Radius>() 
            {
                new Radius() { Value = 200 },
                new Radius() { Value = 400 },
                new Radius() { Value = 600 },
                new Radius() { Value = 800 },
                new Radius() { Value = 1000 }
            };
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

        public ObservableCollection<Radius> Radius
        {
            get
            {
                return radius;
            }
            set
            {
                SetProperty<ObservableCollection<Radius>>(ref radius, value);
            }
        }


        public void Exit(Action onExitCallback)
        {
            onExitCallback();
        }
    }

    public class Radius
    {
        public int Value { get; set; }
    }
}
