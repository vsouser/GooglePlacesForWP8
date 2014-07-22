using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Places.Pages
{
    public partial class PlaceInfoPage : PhoneApplicationPage
    {
        public PlaceInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.PlaceInfoViewModel = new ViewModel.PlaceInfoViewModel(App.PlaceInfoSearchViewModel.PlaceInfo, App.ResultPageViewModel.DistancePlace, App.ResultPageViewModel.SelectPlace.Price_level, App.ResultPageViewModel.SelectPlace.Opening_hours.Open_now);
            LayoutRoot.DataContext = App.PlaceInfoViewModel;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            NavigationService.Navigate(new Uri("/Pages/ResultPage.xaml", UriKind.Relative));
        }

        private void Site_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri(App.PlaceInfoViewModel.PlaceInfo.Website, UriKind.RelativeOrAbsolute);
            webBrowserTask.Show();
        }

        private void Google_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri(App.PlaceInfoViewModel.PlaceInfo.Url, UriKind.RelativeOrAbsolute);
            webBrowserTask.Show();
        }

        private void FormatNumber_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCall = new PhoneCallTask();
            phoneCall.PhoneNumber = App.PlaceInfoViewModel.PlaceInfo.Formatted_phone_number;
            phoneCall.DisplayName = App.PlaceInfoViewModel.PlaceInfo.Name;
            phoneCall.Show();
        }

        private void InternationalNumber_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCall = new PhoneCallTask();
            phoneCall.PhoneNumber = App.PlaceInfoViewModel.PlaceInfo.International_phone_number;
            phoneCall.DisplayName = App.PlaceInfoViewModel.PlaceInfo.Name;
            phoneCall.Show();
        }

    }
}