﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Places.ViewModel;
using Microsoft.Phone.Net.NetworkInformation;

namespace Places.Pages
{
    public partial class MainPanorama : PhoneApplicationPage
    {

        public MainPanorama()
        {
            InitializeComponent();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DeviceNetworkInformation.IsNetworkAvailable == true)
            {
                MainContainer.DataContext = App.MainPanoramaViewModel;
            }
            else
            {
                App.NetworkErrorViewModel.Navigate(() => NavigationService.Navigate(new Uri("/Pages/NetworkError.xaml", UriKind.Relative)));
            }
        }

        private void NerbyTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GooglePlacesApi.Type types = ((GooglePlacesApi.Type)NerbyTile.SelectedItem);
            if (types.Key == GooglePlacesApi.Types.OTHER)
            {
                MessageBox.Show("Полный поиск");
            }
            else
            {
                App.NerbySearchViewModel = new NerbySimplySearchViewModel(types);
                App.NerbySearchViewModel.Navigation(() => NavigationService.Navigate(new Uri("/Pages/NerbySimplySearch.xaml", UriKind.Relative)));
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            App.MainPanoramaViewModel.Exit(() =>
                {
                    while (NavigationService.CanGoBack)
                    {
                        NavigationService.RemoveBackEntry();
                    }
                });
        }
    }
}