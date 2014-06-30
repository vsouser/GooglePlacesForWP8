﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Places.Resources;
using GooglePlacesApi;
using System.Globalization;

namespace Places
{
    public partial class MainPage : PhoneApplicationPage
    {
        private NearbySearchController placeNerbyController;

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

            TypesFactory typesFactory = new TypesFactory(Types.ACCOUNTING);

            LanguageController languageController = new LanguageController();

            string curentLanguage = languageController.GetGooglePlacesLanguage();

            GoogleApiKeyTable googleApiKeyTable = new GoogleApiKeyTable("AIzaSyCmlHiWshBC77iFO8lJp5VqLjZurbSDcXU", "AIzaSyCRuDl06RN51s-rzbICyjagZERWSKRpep4", "AIzaSyAhMx9QEuodwotkLM0MrH-j5_7aHFEgZDo", "AIzaSyD_SAiM0LqhMn0MzJ56KvrdKm1eROoqTM4", "AIzaSyAYQdeRFOz8Vin_pzdmg2ZAr0HjDUyiTO8");

            string key = googleApiKeyTable.GetKey();

            placeNerbyController = new NearbySearchController(key, Sensor.TRUE, GooglePlacesApi.Language.RUSSIAN, "400", "56.8239549679567,60.6172860176859", false, "", "", typesFactory.CreateType(), "", "", Rankby.DISTANCE);
 
            try
            {
                await placeNerbyController.GetPlaces();
                ContentPanel.DataContext = placeNerbyController;

            }
            catch (GooglePlacesApi.SearchPlacesException ex)
            {
                MessageBox.Show(ex.Message, ex.Name, MessageBoxButton.OK);
            }

        }

        private async void AddMore_Click(object sender, EventArgs e)
        {
            if (placeNerbyController.IsNextPage == true)
            {
                await placeNerbyController.GetPlaces();
            }
            else
            {
                MessageBox.Show("Все данные уже загружены");
            }
        }

        private void Places_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.SelectPlace = (GooglePlacesApi.Place)Places.SelectedItem;
            NavigationService.Navigate(new Uri("//PlaceInfo.xaml", UriKind.Relative));
        }
    }
}