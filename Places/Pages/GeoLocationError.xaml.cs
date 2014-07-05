using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Places.Pages
{
    public partial class GeoLocationError : PhoneApplicationPage
    {
        public GeoLocationError()
        {
            InitializeComponent();
        }

        private void Location_Click(object sender, EventArgs e)
        {
            App.GeoLocationErrorViewModel.Navigate(() => Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:")));
        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            App.GeoLocationErrorViewModel.Navigate(() => NavigationService.Navigate(new Uri("/Pages/NerbySimplySearch.xaml", UriKind.Relative)));
        }

        private void Airplane_Click(object sender, EventArgs e)
        {
            App.GeoLocationErrorViewModel.Navigate(() => Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-airplanemode:")));
        }
    }
}