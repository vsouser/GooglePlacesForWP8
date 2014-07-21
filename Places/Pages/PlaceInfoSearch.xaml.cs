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
    public partial class PlaceInfoSearch : PhoneApplicationPage
    {
        public PlaceInfoSearch()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ContentPanel.DataContext = App.NerbySearchViewModel;
            await App.PlaceInfoSearchViewModel.GetData(() => NavigationService.Navigate(new Uri("/Pages/PlaceInfoPage.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/ZeroResultError.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/ApiError.xaml", UriKind.Relative)));
     
        
        }


    }
}