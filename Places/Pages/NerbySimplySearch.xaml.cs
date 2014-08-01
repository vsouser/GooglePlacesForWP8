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
    public partial class NerbySimplySearch : PhoneApplicationPage
    {
        public NerbySimplySearch()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ContentPanel.DataContext = App.NerbySearchViewModel;
            await App.NerbySearchViewModel.GetData(() => NavigationService.Navigate(new Uri("/Pages/GeoLocationError.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/ResultPage.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/ZeroResultError.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/ApiError.xaml", UriKind.Relative)), () => NavigationService.Navigate(new Uri("/Pages/OverLimitQueryError.xaml", UriKind.Relative)));
            
        }
    }
}