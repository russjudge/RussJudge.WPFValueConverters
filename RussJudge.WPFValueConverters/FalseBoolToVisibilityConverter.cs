using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class FalseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                return val ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility val)
            {
                return (val != Visibility.Visible);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
