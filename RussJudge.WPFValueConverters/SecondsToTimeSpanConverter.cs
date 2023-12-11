using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(long), typeof(TimeSpan))]
    public class SecondsToTimeSpanConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                long val = System.Convert.ToInt64(value);

                TimeSpan ts = TimeSpan.FromSeconds(val);
                if (parameter is string parm)
                {
                    try
                    {
                        return ts.ToString(parm, culture);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return ts.ToString();
                }
            }
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan ts)
            {
                return ts.TotalSeconds;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
