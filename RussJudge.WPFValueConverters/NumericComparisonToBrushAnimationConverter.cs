using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RussJudge.WPFValueConverters
{
    public class NumericComparisonToBrushAnimationConverter : IValueConverter
    {
        /// <summary>
        /// Converts object.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.  (operator)|(comparisonValue)|AnimatedBrushParms if match|AnimatedBrushParms if not match</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted object.</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            SolidColorBrush? brush = null;
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
                            var brushOptions = Common.ParmsToAnimatedBrush(2, parm);
                            brush = (Common.NumericOperatorTest(val, oprator, comparisonMatch)) ? brushOptions.Item1 : brushOptions.Item2;
                        }
                    }
                }
            }
            return brush ?? DependencyProperty.UnsetValue;
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
