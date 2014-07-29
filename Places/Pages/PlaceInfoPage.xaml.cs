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
using Microsoft.Phone.UserData;
using System.Device.Location;

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
            App.PlaceInfoViewModel = new ViewModel.PlaceInfoViewModel(App.PlaceInfoSearchViewModel.PlaceInfo, App.ResultPageViewModel.DistancePlace, App.ResultPageViewModel.SelectPlace.Price_level, App.ResultPageViewModel.SelectPlace.Opening_hours.Open_now, App.ResultPageViewModel.UserGeoCoordinate, new GeoCoordinate(App.ResultPageViewModel.SelectPlace.Geometry.Location.Lat, App.ResultPageViewModel.SelectPlace.Geometry.Location.Lng));
            App.PlaceInfoViewModel.InitData();
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

        private void Route_Click(object sender, EventArgs e)
        {
            MapsDirectionsTask direction = new MapsDirectionsTask();

            LabeledMapLocation startLabeled = new LabeledMapLocation("Ваше местоположение", App.PlaceInfoViewModel.UserLocation);

            direction.Start = startLabeled;

            LabeledMapLocation endLabeled = new LabeledMapLocation(App.PlaceInfoViewModel.PlaceInfo.Name, App.PlaceInfoViewModel.PlaceLocation);

            direction.End = endLabeled;

            direction.Show();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            Contacts contacts = new Contacts();

            contacts.SearchAsync(App.PlaceInfoViewModel.PlaceInfo.Name, FilterKind.DisplayName, "Contact search");

            contacts.SearchCompleted += contacts_SearchCompleted;
            
        }

        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (e.Results.Count() > 0)
            {
                MessageBox.Show(" Контакт " + App.PlaceInfoViewModel.PlaceInfo.Name + " уже существует");
            }
            else
            {
                SaveContactTask saveContact = new SaveContactTask();
                saveContact.FirstName = App.PlaceInfoViewModel.PlaceInfo.Name;
                saveContact.HomeAddressStreet = App.PlaceInfoViewModel.PlaceInfo.Formatted_address;
                saveContact.Website = App.PlaceInfoViewModel.PlaceInfo.Website;
                saveContact.WorkPhone = App.PlaceInfoViewModel.PlaceInfo.Formatted_phone_number;
                saveContact.Show();
            }
        }

    }
}