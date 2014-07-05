using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Net.NetworkInformation;

namespace Places.Pages
{
    public partial class NetworkError : PhoneApplicationPage
    {
        public NetworkError()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            if (DeviceNetworkInformation.IsNetworkAvailable == true)
            {
                App.NetworkErrorViewModel.Navigate(() => NavigationService.Navigate(new Uri("/Pages/MainPanorama.xaml", UriKind.Relative)));
            }
        }

        private void WiFi_Click(object sender, EventArgs e)
        {
            App.NetworkErrorViewModel.Navigate(() => Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-wifi:")));
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            App.NetworkErrorViewModel.Navigate(() => Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-cellular:")));
        }

        private void Airplane_Click(object sender, EventArgs e)
        {
            App.NetworkErrorViewModel.Navigate(() => Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-airplanemode:")));
        }
    }
}