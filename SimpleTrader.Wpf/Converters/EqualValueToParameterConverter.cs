using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleTrader.Wpf.Converters
{
    public class EqualValueToParameterConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter != null && (value != null && value.ToString() == parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}