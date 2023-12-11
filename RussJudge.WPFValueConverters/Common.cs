using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RussJudge.WPFValueConverters
{
    internal static class Common
    {
        public static Tuple<SolidColorBrush?, SolidColorBrush?> ParmsToAnimatedBrush(int startIndex, params string[] values)
        {
            SolidColorBrush? item1 = null;
            SolidColorBrush? item2 = null;
            if (values.Length > startIndex)
            {
                item1 = GetAnimatedBrush(values[startIndex]);
            }
            if (values.Length > startIndex + 1)
            {
                item2 = GetAnimatedBrush(values[startIndex + 1]);
            }
            return new Tuple<SolidColorBrush?, SolidColorBrush?>(item1, item2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parmArray"></param>
        /// <returns></returns>
        public static SolidColorBrush? GetAnimatedBrush(string parameters)
        {
            if (parameters == "DEFAULT")
            {
                return null;
            }
            else
            {
                TypeConverter tcColor = new ColorConverter();
                Color fromColor = Colors.Transparent;
                Color toColor = Colors.Red;

                int animationDuration = 1000;
                bool autoReverse = true;

                string[] parmArray = parameters.Split(';');
                bool noAnimation = false;
                RepeatBehavior behavior = new(1);
                foreach (var parm in parmArray)
                {
                    string[] keyValue = parm.Split('=');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0].ToUpperInvariant())
                        {
                            case "COLOR":
                                if (tcColor.ConvertFromString(keyValue[1]) is Color Col)
                                {
                                    fromColor = Col;
                                    toColor = Col;
                                    noAnimation = true;
                                }
                                break;
                            case "FROMCOLOR":
                                if (tcColor.ConvertFromString(keyValue[1]) is Color fCol)
                                {
                                    fromColor = fCol;
                                }
                                break;
                            case "TOCOLOR":
                                if (tcColor.ConvertFromString(keyValue[1]) is Color tCol)
                                {
                                    toColor = tCol;
                                }
                                break;
                            case "REPEATCOUNT":
                                if (keyValue[1].Equals("FOREVER", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    behavior = RepeatBehavior.Forever;
                                }
                                else
                                {
                                    if (int.TryParse(keyValue[1], out int repeatCount))
                                    {
                                        behavior = new RepeatBehavior(repeatCount);
                                    }
                                }
                                break;
                            case "DURATION":
#pragma warning disable CA1806 // Do not ignore method results
                                int.TryParse(keyValue[1], out animationDuration);
#pragma warning restore CA1806 // Do not ignore method results
                                break;
                            case "AUTOREVERSE":
#pragma warning disable CA1806 // Do not ignore method results
                                bool.TryParse(keyValue[1], out autoReverse);
#pragma warning restore CA1806 // Do not ignore method results
                                break;
                        }
                    }
                }

                SolidColorBrush retVal = new(fromColor);
                if (!noAnimation)
                {
                    Color? animationColor = toColor;

                    var switchOffAnimation = new ColorAnimation
                    {
                        From = fromColor,
                        To = animationColor,
                        Duration = TimeSpan.FromMilliseconds(animationDuration),
                        RepeatBehavior = behavior,
                        AutoReverse = autoReverse,
                    };
                    retVal.BeginAnimation(SolidColorBrush.ColorProperty, switchOffAnimation);
                }
                return retVal;
            }
        }

        public static bool OperatorTest(object val, string operatorValue, string compareValue)
        {
            bool retVal;

            string? value = val?.ToString();

            if (value == null)
            {
                value = string.Empty;
            }
            switch (operatorValue)
            {
                case "<":
                case "&lt;":
                    retVal = value.CompareTo(compareValue) < 0;
                    break;
                case "<=":
                case "&lt;=":
                    retVal = value.CompareTo(compareValue) <= 0;
                    break;
                case ">":
                case "&gt;":
                    retVal = value.CompareTo(compareValue) > 0;
                    break;
                case ">=":
                case "&gt;=":
                    retVal = value.CompareTo(compareValue) >= 0;
                    break;
                case "=":
                    retVal = value.Equals(compareValue);
                    break;
                case "!=":
                    retVal = !value.Equals(compareValue);
                    break;
                default:
                    throw new NotSupportedException("Specified Operator is not supported.");
            }
            return retVal;
        }
        /// <summary>
        /// Operator test.
        /// </summary>
        /// <param name="value">first value to check.</param>
        /// <param name="operatorValue">The operator.</param>
        /// <param name="compareValue">Value to compare to.</param>
        /// <remarks>
        /// Standard parameter for this should be: (operator)(compareValue)|(otherparms)
        /// </remarks>
        /// <returns>result.</returns>
        /// <exception cref="NotSupportedException">Thrown if operation is not supported.</exception>
        public static bool NumericOperatorTest(decimal value, string operatorValue, decimal compareValue)
        {
            var result = operatorValue switch
            {
                "&lt;" or "<" => value < compareValue,
                "&lt;=" or "<=" => value <= compareValue,
                "&gt;" or ">" => value > compareValue,
                "&gt;=" or ">=" => value >= compareValue,
                "=" or "==" => value == compareValue,
                "!=" => value != compareValue,
                _ => throw new NotSupportedException("Specified Operator is not supported."),
            };
            return result;
        }
        public static Visibility? StringToVisibility(string value)
        {

            if (Enum.TryParse(typeof(Visibility), value, out object? v))
            {
                return (Visibility)v;
            }
            else
            {
                return null;
            }
        }
        public static Tuple<Visibility?, Visibility?> ParmsToVisibility(int startIndex, params string[] values)
        {
            Visibility? item1 = Visibility.Visible;
            Visibility? item2 = Visibility.Collapsed;

            if (values.Length > startIndex)
            {
                item1 = StringToVisibility(values[startIndex]);
            }
            if (values.Length > startIndex + 1)
            {
                var vis = StringToVisibility(values[startIndex + 1]);
                if (vis == null)
                {
                    if (item1 == null)
                    {
                        item2 = null;
                    }
                    else
                    {
                        item2 = (item1 == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
                    }
                }
                else
                {
                    item2 = vis;
                }
            }
            return new Tuple<Visibility?, Visibility?>(item1, item2);
        }
    }
}
