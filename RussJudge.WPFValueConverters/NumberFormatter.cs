using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    public class NumberFormatter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                decimal val = System.Convert.ToDecimal(value);
                if (parameter is string parm)
                {
                    return val.ToString(parm, culture);
                }
                else
                {
                    return val.ToString(culture);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
