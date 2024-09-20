using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    public class BooleanToIntegerConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int valueIfTrue = 0;
            int valueIfFalse = 0;
            if (parameter is string parm)
            {
                string[] parms = parm.Split('|');
                if (parms.Length > 0)
                {
                    if (int.TryParse(parms[0], out int w))
                    {
                        valueIfTrue = w;
                    }
                }
                if (parms.Length > 1)
                {
                    if (int.TryParse(parms[1], out int w))
                    {
                        valueIfFalse = w;
                    }
                }
            }

            if (value is bool val)
            {
                return val ? valueIfTrue : valueIfFalse;
            }
            else
            {
                return default;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
