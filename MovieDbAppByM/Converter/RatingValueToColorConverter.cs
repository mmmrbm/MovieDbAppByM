using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MovieDbAppByM.Converter
{
    public class RatingValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush lowestRatingColor = Brushes.Red;
            SolidColorBrush lowRatingColor = Brushes.Orange;
            SolidColorBrush midRatingColor = Brushes.Yellow;
            SolidColorBrush highRatingColor = Brushes.Green;

            var decimalValue = (float)value;

            if (decimalValue > 65)
            {
                return highRatingColor;
            }
            if (decimalValue > 50)
            {
                return midRatingColor;
            }
            if (decimalValue > 35)
            {
                return lowRatingColor;
            }
            return lowestRatingColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
