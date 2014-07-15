using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Places.Helpers
{
    public class RatingLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return 0.0;
            }
            else
            {
                string number = value.ToString();
                string convertNumber = String.Empty;

                if (number.Count() > 1)
                {
                    if (number[1] == '.')
                    {
                        convertNumber = (number[0].ToString() + ',' + number[2].ToString()).ToString();
                    }
                }
                else
                {
                    convertNumber = number;
                }

                double rating = double.Parse(convertNumber);
                return rating;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
