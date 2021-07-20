using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace iQuest.CaesarCipher.PresentationBase.ValueConverters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}