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

            map.SetView(App.ResultPageViewModel.UserGeoCoordinate, 16);
        }
    }
}