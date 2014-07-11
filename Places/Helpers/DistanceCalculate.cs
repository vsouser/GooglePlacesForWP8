using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.Helpers
{
    public static class DistanceCalculate
    {
        public static double Calculate(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            double DEG_TO_RAD = 0.017453292519943295769236907684886;
            double EARTH_RADIUS_IN_METERS = 6372797.560856;

            double latitudeArc = (latitude1 - latitude2) * DEG_TO_RAD;
            double longitudeArc = (longitude1 - longitude2) * DEG_TO_RAD;

            double latitudeH = Math.Sin(latitudeArc * 0.5);
            latitudeH *= latitudeH;
            double lontitudeH = Math.Sin(longitudeArc * 0.5);
            lontitudeH *= lontitudeH;

            double tmp = Math.Cos(latitude1 * DEG_TO_RAD) * Math.Cos(latitude2 * DEG_TO_RAD);

            return (EARTH_RADIUS_IN_METERS * 2.0 * Math.Asin(Math.Sqrt(latitudeH + tmp * lontitudeH))) / 1000;
        }
    }
}
