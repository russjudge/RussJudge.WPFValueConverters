using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(decimal), typeof(decimal))]
    [Obsolete("Use \"NumericMathConverter\" instead.")]
    public class NumericAdjustmentConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                decimal val = System.Convert.ToDecimal(value);
                if (parameter is string parm)
                {
                    if (decimal.TryParse(parm, out decimal adjustmentValue))
                    {
                        return (val + adjustmentValue);
                    }
                    else
                    {
                        return val;
                    }
                }
                else
                {
                    return val;
                }
            }
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                decimal val = System.Convert.ToDecimal(value);
                if (parameter is string parm)
                {
                    if (decimal.TryParse(parm, out decimal adjustmentValue))
                    {
                        return (val - adjustmentValue);
                    }
                    else
                    {
                        return val;
                    }
                }
                else
                {
                    return val;
                }
            }
        }
    }
}
