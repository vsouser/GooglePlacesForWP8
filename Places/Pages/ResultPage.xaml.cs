using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media;
using Microsoft.Phone.Tasks;

namespace Places.Pages
{
    public partial class ResultPage : PhoneApplicationPage
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            App.ResultPageViewModel = new ViewModel.ResultPageViewModel(App.NerbySearchViewModel.SearchController, App.NerbySearchViewModel.Location);
            LayoutRoot.DataContext = App.ResultPageViewModel;

            if (App.ResultPageViewModel.SearchPlacesController.IsNextPage == true)
            {
                ApplicationBar.IsVisible = true;
            }
            else
            {
                ApplicationBar.IsVisible = false;
            }

            if (App.ResultPageViewModel.SelectPlace == null)
            {
                LayoutRoot.SelectedIndex = 0;
            }


            map.SetView(App.ResultPageViewModel.UserGeoCoordinate, 15);

            map.Layers.Add(App.ResultPageViewModel.CreateLocationPlaces());

            map.Layers.Add(App.ResultPageViewModel.CreatePinPlaces(App.ResultPageViewModel.SearchPlacesController.Places, placeMouseButtonTap));

        }

        private void placeMouseButtonTap(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var longitude = ((Pushpin)sender).GeoCoordinate.Longitude;
            var latitude = ((Pushpin)sender).GeoCoordinate.Latitude;

            App.ResultPageViewModel.FindPlace(latitude, longitude);

            map.SetView(new GeoCoordinate() { Longitude = longitude, Latitude = latitude }, 17);

            LayoutRoot.SelectedIndex = 2;
        }

        private async void More_Click(object sender, EventArgs e)
        {
            Progress.Visibility = System.Windows.Visibility.Visible;
            ApplicationBar.IsVisible = false;
            LocalSearch.IsReadOnly = true;
            Places.IsHitTestVisible = false;

            await App.ResultPageViewModel.GetMorePlaces();

            map.Layers.Clear();

            map.Layers.Add(App.ResultPageViewModel.CreateLocationPlaces());

            map.Layers.Add(App.ResultPageViewModel.CreatePinPlaces(App.ResultPageViewModel.SearchPlacesController.Places, placeMouseButtonTap));

            Progress.Visibility = System.Windows.Visibility.Collapsed;
            LocalSearch.IsReadOnly = false;
            Places.IsHitTestVisible = true;

            if (App.ResultPageViewModel.SearchPlacesController.IsNextPage == true)
            {
                ApplicationBar.IsVisible = true;
                
            }
            else
            {
                ApplicationBar.IsVisible = false;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            if (LayoutRoot.SelectedIndex > 0)
            {
                e.Cancel = true;
                LayoutRoot.SelectedIndex -= 1;
            }
            else
            {
                NavigationService.Navigate(new Uri("/Pages/MainPanorama.xaml", UriKind.Relative));
            }
        }

        private void LocalSearhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            App.ResultPageViewModel.LocalSearchPlace(text);
        }

        private void Places_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Places.SelectedItem != null)
            {
                var selectedPlave = (GooglePlacesApi.Place)Places.SelectedItem;

                App.ResultPageViewModel.FindPlace(selectedPlave.Geometry.Location.Lat, selectedPlave.Geometry.Location.Lng);

                map.SetView(new GeoCoordinate() { Longitude = selectedPlave.Geometry.Location.Lng, Latitude = selectedPlave.Geometry.Location.Lat }, 17);

                LayoutRoot.SelectedIndex = 2;
            }
        }

        private void Map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LayoutRoot.SelectedIndex = 1;
        }

        private void Route_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MapsDirectionsTask direction = new MapsDirectionsTask();

            LabeledMapLocation startLabeled = new LabeledMapLocation("Ваше местоположение", App.ResultPageViewModel.UserGeoCoordinate);

            direction.Start = startLabeled;

            LabeledMapLocation endLabeled = new LabeledMapLocation(App.ResultPageViewModel.SelectPlace.Name, new GeoCoordinate(App.ResultPageViewModel.SelectPlace.Geometry.Location.Lat, App.ResultPageViewModel.SelectPlace.Geometry.Location.Lng));

            direction.End = endLabeled;

            direction.Show();
        }

        private void MoreInfo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.PlaceInfoSearchViewModel = new ViewModel.PlaceInfoSearchViewModel(App.ResultPageViewModel.SelectPlace.Reference);
            App.PlaceInfoSearchViewModel.Navigation(() => NavigationService.Navigate(new Uri("/Pages/PlaceInfoSearch.xaml", UriKind.Relative)));
        }

    }
}