using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Places.ViewModel;

namespace Places.Pages
{
    public partial class MainPanorama : PhoneApplicationPage
    {
        MainPanoramaViewModel mainPanoramaViewModel;

        public MainPanorama()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            mainPanoramaViewModel = new MainPanoramaViewModel(App.TypesContoller.Require);

            MainContainer.DataContext = mainPanoramaViewModel;
        }
    }
}