using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using System.Windows;

namespace Places.ViewModel
{
    public class ResultPageViewModel : GooglePlacesApi.NotifyPropertyBase
    {
        private NearbySearchController searchPlacesController;
        private GeoCoordinate userGeoCoordinate;
        private Place selectPlace;

        public NearbySearchController SearchPlacesController
        {
            get
            {
                return searchPlacesController;
            }
            set
            {
                SetProperty<NearbySearchController>(ref searchPlacesController, value);
            }
        }

        public GeoCoordinate UserGeoCoordinate 
        {
            get
            {
                return userGeoCoordinate;
            }
            set
            {
                SetProperty<GeoCoordinate>(ref userGeoCoordinate, value);
            }
        }

        public Place SelectPlace
        {
            get
            {
                return selectPlace;
            }
            set
            {
                SetProperty<Place>(ref selectPlace, value);
            }
        }

        public MapLayer CreateLocationPlaces()
        {
            MapLayer unitsLayer = new MapLayer();
            var pin = new Pushpin();
            pin.GeoCoordinate = UserGeoCoordinate;
            pin.Background = new System.Windows.Media.SolidColorBrush() { Color = Helpers.ColorConverting.ConvertStringToColor("#DE9317") };
            pin.Style = (Style)App.Current.Resources["LocationPinStyle"];
            MapOverlay LocationOverlay = new MapOverlay();
            LocationOverlay.Content = pin;
            LocationOverlay.PositionOrigin = new Point(0.7, 0.7);
            LocationOverlay.GeoCoordinate = UserGeoCoordinate;
            unitsLayer.Add(LocationOverlay);
            return unitsLayer;
        }

        public MapLayer CreatePinPlaces(System.Collections.ObjectModel.ObservableCollection<GooglePlacesApi.Place> place, System.Windows.Input.MouseButtonEventHandler handler)
        {
            MapLayer unitsLayer = new MapLayer();
            for (int i = 0; i < place.Count; i++)
            {
                var pin = new Pushpin();
                pin.GeoCoordinate = new System.Device.Location.GeoCoordinate(place[i].Geometry.Location.Lat, place[i].Geometry.Location.Lng);
                pin.Content = place[i].Name;
                pin.MouseLeftButtonUp += handler;
                pin.Style = (Style)App.Current.Resources["PlacePinStyle"];
                MapOverlay LocationOverlay = new MapOverlay();
                LocationOverlay.Content = pin;
                LocationOverlay.PositionOrigin = new Point(0.7, 0.7);
                LocationOverlay.GeoCoordinate = new System.Device.Location.GeoCoordinate(place[i].Geometry.Location.Lat, place[i].Geometry.Location.Lng);
                unitsLayer.Add(LocationOverlay);
            }

            return unitsLayer;
        }

        public void FindPlace(double lat, double lng)
        {
            var query = from place in searchPlacesController.Places
                        where place.Geometry.Location.Lat == lat && place.Geometry.Location.Lng == lng
                        select place;

            SelectPlace = query.FirstOrDefault();
        }

        public ResultPageViewModel(NearbySearchController searchPlacesController, GooglePlacesApi.Location location)
        {
            this.searchPlacesController = searchPlacesController;
            UserGeoCoordinate = new GeoCoordinate() { Latitude = location.Lat, Longitude = location.Lng};          
        }
    }
}
