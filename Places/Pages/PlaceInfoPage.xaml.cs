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
    public partial class PlaceInfoPage : PhoneApplicationPage
    {
        public PlaceInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.PlaceInfoViewModel = new ViewModel.PlaceInfoViewModel(App.PlaceInfoSearchViewModel.PlaceInfo);
            LayoutRoot.DataContext = App.PlaceInfoViewModel;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            NavigationService.Navigate(new Uri("/Pages/ResultPage.xaml", UriKind.Relative));
        }

    }
}