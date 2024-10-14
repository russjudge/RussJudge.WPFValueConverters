using System.Globalization;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibilityIfNull = Visibility.Collapsed;
            Visibility visibilityIfNotNull = Visibility.Visible;
            if (parameter is string parm)
            {
                var parms = parm.Split('|');
                var visibilityOptions = Common.ParmsToVisibility(0, parms);
                if (visibilityOptions != null)
                {
                    if (visibilityOptions.Item1 != null)
                    {
                        visibilityIfNull = visibilityOptions.Item1.Value;
                    }
                    if (visibilityOptions.Item2 != null)
                    {
                        visibilityIfNotNull = visibilityOptions.Item2.Value;
                    }
                }
            }
            Visibility retVal = (value == null || (value is string val && string.IsNullOrEmpty(val))) ? visibilityIfNull : visibilityIfNotNull;
            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
