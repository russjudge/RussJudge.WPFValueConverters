using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class BytesToMBFormatter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            const int divider = 1024;
#if NET8_0_OR_GREATER
            string[] typesTo = [string.Empty, "KB", "MB", "GB", "TB", "PB", "EB"];
#else
            string[] typesTo = { string.Empty, "KB", "MB", "GB", "TB", "PB", "EB" };
#endif
            if (value is int bytes)
            {
                int pow = 0;

                int newVal = bytes;
                while (newVal > divider && pow < typesTo.Length)
                {
                    pow++;
                    newVal /= divider;
                }
                string format = "N1";
                if (pow == 0)
                {
                    format = "N0";
                }
                return newVal.ToString(format, culture) + typesTo[pow];
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
