using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace GooglePlacesApi
{
    public class GeoLocationController
    {
        private Geolocator geolocator;

        public GeoLocationController()
        {

        }

        public async Task<Location> GetLocation(uint desiredAccuracyInMeters = 50)
        {

            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = desiredAccuracyInMeters;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
                return new Location(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
            }
            catch
            {
                throw new Exception("Could not determine location");
            }

        }
    }
}
