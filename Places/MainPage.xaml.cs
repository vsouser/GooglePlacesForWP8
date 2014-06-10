using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Places.Resources;

namespace Places
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();

            // Пример кода для локализации ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Пример кода для построения локализованной панели ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Установка в качестве ApplicationBar страницы нового экземпляра ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Создание новой кнопки и установка текстового значения равным локализованной строке из AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Создание нового пункта меню с локализованной строкой из AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            GooglePlacesApi.TypesFactory typesFactory = new GooglePlacesApi.TypesFactory(GooglePlacesApi.Types.Bar, GooglePlacesApi.Types.Food, GooglePlacesApi.Types.Restaurant);

           

            GooglePlacesApi.GeoLocationController geoLocationController = new GooglePlacesApi.GeoLocationController();
            var location = await geoLocationController.GetLocation();

            GooglePlacesApi.PlacesNearbyController pnc = new GooglePlacesApi.PlacesNearbyController("AIzaSyDuPZrLWqob5RVUuYjYSsIOzZEFw4sgm1s", GooglePlacesApi.Sensor._true, GooglePlacesApi.Output._json, location.ApiFormat, "200", GooglePlacesApi.Language.RUSSIAN, typesFactory.CreateType());

            var places =  await pnc.GetPlaces();
            MessageBox.Show(places.Result);
        }
    }
}