using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{

    [ValueConversion(typeof(string), typeof(string))]
    public class StringReplacementConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string val)
            {
                if (parameter is string parms)
                {
                    var parm = parms.Split('|');
                    if (parm.Length < 2)
                    {
                        throw new InvalidOperationException("Invalid parameter--must be 2 parameters, the string to match, and the string to replace to.");
                    }
                    else
                    {
                        return val.Replace(parm[0], parm[1]);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid parameter--must be 2 parameters, the string to match, and the string to replace to.");
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string val)
            {
                if (parameter is string parms)
                {
                    var parm = parms.Split('|');
                    if (parm.Length < 2)
                    {
                        throw new InvalidOperationException("Invalid parameter--must be 2 parameters, the string to match, and the string to replace to.");
                    }
                    else
                    {
                        return val.Replace(parm[1], parm[0]);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid parameter--must be 2 parameters, the string to match, and the string to replace to.");
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
