using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retValueIfNull = false;
            if (parameter is string parm)
            {
                retValueIfNull = (parm.Equals(true.ToString(), StringComparison.InvariantCultureIgnoreCase));
            }

            var retVal = (value == null || (value is string val && string.IsNullOrEmpty(val))) ? retValueIfNull : !retValueIfNull;

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}