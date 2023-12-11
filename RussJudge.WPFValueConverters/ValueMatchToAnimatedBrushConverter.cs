using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    public class ValueMatchToAnimatedBrushConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                if (parameter is string parm)
                {
                    var parms = parm.Split("|");
                    var visibilityOptions = Common.ParmsToAnimatedBrush(2, parms);

                    var retVal = Common.OperatorTest(value, parms[0], parms[1]) ? visibilityOptions.Item1 : visibilityOptions.Item2;
                    return retVal ?? DependencyProperty.UnsetValue;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
