using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {

    public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = value as bool?;

            if (b.HasValue)
            {
                return (b.Value) ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Transparent);
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var c = value as SolidColorBrush;

            if (c != null)
            {
                return c.Color  == Colors.Red;
            }

            return null;
        }
    }
}
