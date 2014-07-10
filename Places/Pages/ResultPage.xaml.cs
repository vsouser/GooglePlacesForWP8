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

            App.ResultPageViewModel = new ViewModel.ResultPageViewModel(App.NerbySearchViewModel.NerbySearch, App.NerbySearchViewModel.Location);
            LayoutRoot.DataContext = App.ResultPageViewModel;

            if (App.ResultPageViewModel.SearchPlacesController.IsNextPage == true)
            {
                ApplicationBar.IsVisible = true;
            }
            else
            {
                ApplicationBar.IsVisible = false;
            }


            map.SetView(App.ResultPageViewModel.UserGeoCoordinate, 17);

            map.Layers.Add(App.ResultPageViewModel.CreateLocationPlaces());

            map.Layers.Add(App.ResultPageViewModel.CreatePinPlaces(App.ResultPageViewModel.SearchPlacesController.Places, placeMouseButtonTap));

        }

        private void placeMouseButtonTap(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var longitude = ((Pushpin)sender).GeoCoordinate.Longitude;
            var latitude = ((Pushpin)sender).GeoCoordinate.Latitude;

            App.ResultPageViewModel.FindPlace(latitude, longitude);

            map.SetView(new GeoCoordinate() { Longitude = longitude, Latitude = latitude }, 19);

            LayoutRoot.SelectedIndex = 2;
        }

        private async void More_Click(object sender, EventArgs e)
        {
            await App.ResultPageViewModel.SearchPlacesController.GetPlaces();

            map.Layers.Clear();

            map.Layers.Add(App.ResultPageViewModel.CreateLocationPlaces());

            map.Layers.Add(App.ResultPageViewModel.CreatePinPlaces(App.ResultPageViewModel.SearchPlacesController.Places, placeMouseButtonTap));

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
            NavigationService.Navigate(new Uri("/Pages/MainPanorama.xaml", UriKind.Relative));
        }

    }
}