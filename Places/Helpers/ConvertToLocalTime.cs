using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Places.Helpers
{
    public class ConvertToLocalTime : IValueConverter
    {
        public static string ConvertTimeToLocal(double unixtimestamp)
        {
            try
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                var time = origin.AddSeconds(unixtimestamp).ToString("dd MMMM yyyy");
                return time;
            }
            catch (ArgumentOutOfRangeException)
            {
                var time = "1 января 1970";
                return time;
            }
        }



        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double number = double.Parse(value.ToString());
            return ConvertTimeToLocal(number);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
