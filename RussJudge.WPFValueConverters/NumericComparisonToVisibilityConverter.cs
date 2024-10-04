using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    public class NumericComparisonToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts object.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.  (operator)|(comparisonValue)|Visibility if match|Visibility if not match</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted object.</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Visibility? retVal = null;
            if (value != null)
            {
                decimal val = System.Convert.ToDecimal(value);
                if (parameter is string parms)
                {
                    string[] parm = parms.Split('|');

                    string oprator = parm[0];

                    if (parm.Length > 1)
                    {
                        if (decimal.TryParse(parm[1], out decimal comparisonMatch))
                        {
                            var visibilityOptions = Common.ParmsToVisibility(2, parm);
                            retVal = Common.NumericOperatorTest(val, oprator, comparisonMatch) ? visibilityOptions.Item1 : visibilityOptions.Item2;
                        }
                    }
                }

                return (retVal == null) ? DependencyProperty.UnsetValue : retVal;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// Unconverts an object.
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
