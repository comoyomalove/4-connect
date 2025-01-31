using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace _4_connect.Views.Converters
{
    // Define a local Visibility enum
    public enum Visibility
    {
        Visible,
        Collapsed
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
                return visibility == Visibility.Visible;
            return false;
        }
    }
}