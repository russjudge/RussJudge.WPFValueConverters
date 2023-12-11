using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    /// <summary>
    /// Opposite bool converter.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class OppositeBoolConverter : IValueConverter
    {
        /// <summary>
        /// Convert object.
        /// </summary>
        /// <param name="value">Object to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted object.</returns>
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                return !val;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// Unconvert object.
        /// </summary>
        /// <param name="value">Object to unconvert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Unconverted object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}

