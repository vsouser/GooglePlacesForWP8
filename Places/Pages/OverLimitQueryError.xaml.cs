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
    public partial class OverLimitQueryError : PhoneApplicationPage
    {
        public OverLimitQueryError()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            NavigationService.Navigate(new Uri("/Pages/MainPanorama.xaml", UriKind.Relative));
        }
    }
}