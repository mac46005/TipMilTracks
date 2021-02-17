using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TipMilTracks.Converters
{
    class ItemTypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string itemType = (string)value;
            if (itemType == "Tip")
            {
                return (Color)Application.Current.Resources["TipColor"];
            }
            else
            {
                return (Color)Application.Current.Resources["MileColor"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
