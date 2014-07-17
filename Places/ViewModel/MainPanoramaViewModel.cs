using Places.Helpers;
using Places.Helpers.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Places.ViewModel
{
    public class MainPanoramaViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        private ObservableCollection<GooglePlacesApi.Type> require;
        private MultiSelectCollection<GooglePlacesApi.Type> all;
        private ObservableCollection<Radius> radius;

        private bool hasTextSearch;

        public bool HasTextSearch
        {
            get
            {
                return hasTextSearch;
            }
            set
            {
                SetProperty<bool>(ref hasTextSearch, value);
            }
        }

        

        public void ValidateQuery(string query, TextBox queryTextBox)
        {
            if (String.IsNullOrEmpty(query) == true)
            {
                queryTextBox.BorderBrush = new System.Windows.Media.SolidColorBrush() { Color = Colors.Red };
                HasTextSearch = false;
            }
            else 
            {
                HasTextSearch = true;
            }
        }

        public void QueryBoxDefault(TextBox queryTextBox)
        {
            queryTextBox.BorderBrush = new System.Windows.Media.SolidColorBrush() { Color = ColorConverting.ConvertStringToColor("#FF1BA1E2") };
        }


        public MainPanoramaViewModel(List<GooglePlacesApi.Type> require, List<GooglePlacesApi.Type> all)
        {
            this.require = new ObservableCollection<GooglePlacesApi.Type>(require);
            this.all = new MultiSelectCollection<GooglePlacesApi.Type>(all); 
            this.radius = new ObservableCollection<Radius>() 
            {
                new Radius() { Value = "" },
                new Radius() { Value = "1000" },
                new Radius() { Value = "5000" },
                new Radius() { Value = "10000" },
                new Radius() { Value = "15000" }
            };
        }

        public MultiSelectCollection<GooglePlacesApi.Type> All
        {
            get
            {
                return all;
            }
            set
            {
                SetProperty <MultiSelectCollection<GooglePlacesApi.Type>>(ref all, value);
            }
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
        public string Value { get; set; }
    }
}
