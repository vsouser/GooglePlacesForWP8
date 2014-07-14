using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace Places.Helpers
{
    public class OpenNowConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool openNow = (bool)value;

            if (openNow)
            {
                var filename = "Assets/Open.png";

                Uri uri = new Uri(filename, UriKind.Relative);
                StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(resourceInfo.Stream);

                return bmp;
            }
            else
            {
                var filename = "Assets/Closed.png";

                Uri uri = new Uri(filename, UriKind.Relative);
                StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(resourceInfo.Stream);

                return bmp;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
