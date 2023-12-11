using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string parm)
            {
                var parms = parm.Split('|');
                var visibilityOptions = Common.ParmsToVisibility(0, parms);
                var retVal = (value == null || (value is string val && string.IsNullOrEmpty(val))) ? visibilityOptions.Item1 : visibilityOptions.Item2;
                return (retVal == null) ? DependencyProperty.UnsetValue : retVal;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
