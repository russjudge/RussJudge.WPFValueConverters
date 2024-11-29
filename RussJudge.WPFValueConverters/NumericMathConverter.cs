using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(decimal), typeof(decimal))]
    public class NumericMathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                double val = System.Convert.ToDouble(value);
                if (parameter is string parm)
                {
                    string[] parms = parm.Split('|');
                    //Parm syntax: "<mathoperator (+,-,*,/,%, pow, & (&amp;), ^, |)
                    if (parms.Length > 0)
                    {
                        if ("x+x-x*x/x%xPOWxABSxCOSxSINxCBRTxMINxMAXxACOSxACOSHxASINxASINHxSINHxCOSHxTANxTANHxATANxATAN2xATANHxCEILINGxFLOORxROUNDxSQRTxTRUNCATExLOGx".Contains("x" + parms[0].ToUpperInvariant() + "x"))
                        {
                            if (double.TryParse(parms[1], out double adjustmentValue))
                            {
                                switch (parms[0].ToUpperInvariant())
                                {
                                    case "+":
                                        return val + adjustmentValue;
                                    case "-":
                                        return val - adjustmentValue;
                                    case "*":
                                        return val * adjustmentValue;
                                    case "/":
                                        return val / adjustmentValue;
                                    case "%":
                                        return val % adjustmentValue;
                                    case "POW":
                                        return Math.Pow(val, adjustmentValue);
                                    case "ABS":
                                        return Math.Abs(val);
                                    case "COS":
                                        return Math.Cos(val);
                                    case "COSH":
                                        return Math.Cosh(val);
                                    case "SIN":
                                        return Math.Sin(val);
                                    case "CBRT":
                                        return Math.Cbrt(val);
                                    case "MIN":
                                        return Math.Min(val, adjustmentValue);
                                    case "MAX":
                                        return Math.Max(val, adjustmentValue);
                                    case "ACOS":
                                        return Math.Acos(val);
                                    case "ACOSH":
                                        return Math.Acosh(val);
                                    case "ASIN":
                                        return Math.Asin(val);
                                    case "ASINH":
                                        return Math.Asinh(val);
                                    case "SINH":
                                        return Math.Sinh(val);
                                    case "TAN":
                                        return Math.Tan(val);
                                    case "TANH":
                                        return Math.Tanh(val);
                                    case "ATAN":
                                        return Math.Atan(val);
                                    case "ATAN2":
                                        return Math.Atan2(val, adjustmentValue);
                                    case "ATANH":
                                        return Math.Atanh(val);
                                    case "CEILING":
                                        return Math.Ceiling(val);
                                    case "FLOOR":
                                        return Math.Floor(val);
                                    case "ROUND":
                                        if (int.TryParse(parms[1], out int intParm))
                                        {
                                            return Math.Round(val, intParm);
                                        }
                                        else
                                        {
                                            return Math.Round(val);
                                        }
                                    case "SQRT":
                                        return Math.Sqrt(val);
                                    case "TRUNCATE":
                                        return Math.Truncate(val);
                                    case "LOG":
                                        return Math.Log(val, adjustmentValue);
                                    default:
                                        return value;
                                }
                            }
                            else if ("x&x&amp;x^x\\x".Contains("x" + parms[0] + "x"))
                            {
                                long val1 = System.Convert.ToInt64(value);
                                if (long.TryParse(parms[1], out long adjustment1))
                                {
                                    return parms[0] switch
                                    {
                                        "&" or "&amp;" => val1 & adjustment1,
                                        "^" => val1 ^ adjustment1,
                                        "\\" => val1 | adjustment1,
                                        _ => value,
                                    };
                                }
                                else
                                {
                                    return value;
                                }
                            }
                            else if ("x<<x&lt;&lt;x>>x&gt;&gt;x>>>x&gt;&gt;&gt;x".Contains("x" + parms[0] + "x"))
                            {
                                int val1 = System.Convert.ToInt32(value);
                                if (int.TryParse(parms[1], out int adjustment1))
                                {
                                    switch (parms[0])
                                    {
                                        case "<<":
                                        case "&lt;&lt;":
                                            return val1 << adjustment1;
                                        case ">>":
                                        case "&gt;&gt;":
                                            return val1 >> adjustment1;
                                        case ">>>":
                                        case "&gt;&gt;&gt;":
#if NET7_0_OR_GREATER
                                            return val1 >>> adjustment1;
#else
                                            return value;                                      
#endif
                                        default:
                                            return value;
                                    }
                                }
                                else
                                {
                                    return value;
                                }
                            }
                            else
                            {
                                return value;
                            }
                        }
                        else
                        {
                            return value;
                        }
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    return value;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
