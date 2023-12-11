using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(string), (typeof(string)))]
    public class FullFilePathToNameConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string? val = value.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    FileInfo f = new(val);
                    return f.Name;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
