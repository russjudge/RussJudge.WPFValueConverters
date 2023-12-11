using System.Globalization;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    public class CurrencyFormatter : IValueConverter
    {
        /// <summary>
        /// Convert object.
        /// </summary>
        /// <param name="value">object to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted object.</returns>
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return System.Convert.ToDecimal(value).ToString("C", culture);
            }
            else
            {
                return value;
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
        /// <exception cref="NotImplementedException">Thrown.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
