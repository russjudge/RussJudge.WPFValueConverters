using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BooleanToBrushAnimationConverter : IValueConverter
    {
        /// <summary>
        /// Convert object.
        /// </summary>
        /// <param name="value">Object to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.&lt;boolValueToMatch&gt;|fromColor=;toColor=;repeatCount=;duration=;autoreverse=</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //Parameters = <boolValueToMatch-default true>|<brush definition on match>|<brush definiton on mismatch>
            bool? inValue = null;
            if (value is bool val)
            {
                inValue = val;
            }
            else
            {
                if (value is string s)
                {
                    if (bool.TryParse(s, out val))
                    {
                        inValue = val;
                    }
                }
                else
                {
                    try
                    {
                        inValue = System.Convert.ToBoolean(value);
                    }
                    catch { }
                }
            }
            if (inValue != null)
            {
                if (parameter is string parms)
                {
                    var parmArray = parms.Split('|');

                    if (bool.TryParse(parmArray[0], out bool valueMatch))
                    {
                        var brushOptions = Common.ParmsToAnimatedBrush(1, parmArray);
                        var retVal = (inValue == valueMatch) ? brushOptions.Item1 : brushOptions.Item2;

                        return retVal ?? DependencyProperty.UnsetValue;
                    }
                }
            }

            return DependencyProperty.UnsetValue;
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
