using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GooglePlacesApi;

namespace Places
{
    public partial class PlaceInfo : PhoneApplicationPage
    {
        public PlaceInfo()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);



            GooglePlacesApi.PlaceInfoController placeInfoController = new GooglePlacesApi.PlaceInfoController(App.GoogleApiKeyTable.GetKey(), App.SelectPlace.Reference, GooglePlacesApi.Sensor.TRUE, "", App.LanguageController.GetGooglePlacesLanguage());
            var info = await placeInfoController.GetPlaceInfo();

            MessageBox.Show(info.Formatted_address);
        }
    }
}