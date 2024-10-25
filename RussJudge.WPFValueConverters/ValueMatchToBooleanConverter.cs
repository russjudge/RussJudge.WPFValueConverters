using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{

    public class ValueMatchToBooleanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
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
                    bool matchReturn = (parms.Length <= 2 || parms[2].Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase));
                    bool noMatchReturn = !matchReturn;
                    return Common.OperatorTest(value, parms[0], parms[1]) ? matchReturn : noMatchReturn;
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
