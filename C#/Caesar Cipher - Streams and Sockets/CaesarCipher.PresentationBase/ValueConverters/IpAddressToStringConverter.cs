using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Data;

namespace iQuest.CaesarCipher.PresentationBase.ValueConverters
{
    public class IpAddressToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IPAddress ipAddress)
                return ipAddress.ToString();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                bool success = IPAddress.TryParse(stringValue, out IPAddress ipAddress);
                return success ? ipAddress : DependencyProperty.UnsetValue;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}