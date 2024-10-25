# RussJudge.WPFValueConverters

A collection of ValueConverters that I've built over the years.

All these are ValueConverters to be added to the Xaml of a WPF control.

For examples on how to use these ValueConverters, please see the example project on the Github repository page at <https://github.com/russjudge/RussJudge.WPFValueConverters>.

## BooleanToBrushAnimationConverter

This converter will take a boolean value and generate a System.Windows.Media.SolidColorBrush.  Based on the parameters provided, the brush can be animated.
See the addendum to this readme for details on these parameters.

Parameter syntax: 

ConverterParameter='&lt;boolValueToMatch-default true&gt;|&lt;brush definition on match&gt;|&lt;brush definiton on mismatch&gt;'

## BooleanToIntegerConverter

This converter will take a boolean value and generate an Integer value.  The parameters determine the values returned based on true or false.

Parameter syntax: 

ConverterParameter='&lt;valueToReturnIfTrue&gt;|&lt;valueToReturnIfFalse&gt;'

## BytesToMBFormatter

This converts an int64 number into a string formatted by culture.  It assumes the number represents bytes and divides by factors of 1024 to 
represent KB, MB, GB, TB, PB, or EB so that the result is a number greater than 1 and less than 1,024.

For example, if the number is 248332132, you will convert this to 236.0MB.


## CurrencyFormatter
This converter takes a number and formats it to a currency value based on the culture.  For example, in the US, 233888.23 will convert to $233,888.23.

## DateFormatter
This converter takes a datetime value and formats it to a human-readable format based on the culture or using the format passed as the converter parameter.

Parameter syntax (optional):

ConverterParameter='&lt;Standard date/time format codes&gt;'


## FalseBoolToVisibilityConverter
Converts a boolean value to Visibility, false being Visible, while true is Collapsed.  This is to produce the opposite behavior to BooleanToVisibilityConverter.

## FullFilePathToNameConverter
This converts a string that represents the full path to a file.  The result will be simply the file name excluding the path to that file.

## NullToAnimatedBrushConverter
Converts a nullable object to a SolidColorBrush.   The brush will depend on the parameters passed and can define one brush for a null value
and another brush for a non-null value.  If the value is an empty string, it will return the same as if the value were null.

Parameter Syntax:

ConverterParameter='&lt;BrushIfNull&gt;|&lt;BrushIfNotNull&gt;'

## NullToBooleanConverter
Converts a nullable objects to a boolean value, based on parameters passed. If the object is not null, then the opposite 
boolean value is returned.

Parameter Syntax (optional, default is false if null, true if not null):

ConverterParameter='&lt;BooleanValueIfNull&gt;'


## NullToVisibilityConverter
Converts a nullable objects to Visibility, based on parameters passed.

Parameter Syntax (optional, default is Collapsed if null, Visible if not null):

ConverterParameter='&lt;VisibilityIfNull&gt;|&lt;VisibilityIfNotNull&gt;'

## NumberFormatter
Formats a number, based on the culture and parameters passed.

Parameter Syntax (optional):

ConverterParameter='<Standard number format codes>'


## NumericAdjustmentConverter
*Deprecated* *Use* *NumericMathConverter* *instead*.

Adds a value to a number, set by the parameter.  A negative number can be added to the value.

Parameter Syntax:

ConverterParameter='&lt;NumberToAdd&gt;'

## NumericComparisonToBrushAnimationConverter
Compares a numeric value to a number in the parameter and converts to a brush.

Parameter Syntax:
ConverterParameter='&lt;operator&gt;|&lt;comparisonValueMatch&gt;|&lt;brushOnTrue&gt;|&lt;brushOnFalse&gt;'

## NumericComparisonToVisibilityConverter
Compares a numeric value to a number in the parameter and converts to visibility.

Parameter Syntax:
ConverterParameter='&lt;operator&gt;|&lt;comparisonValueMatch&gt;|&lt;VisibilityOnTrue&gt;|&lt;VisibilityOnFalse&gt;'

## NumericMathConverter
Adjusts a bound value by a number, set by the parameter.  See the Addendum for valid Math Operators.

Parameter Syntax:

ConverterParameter='&lt;mathOperator&gt;|&lt;NumberToAdd&gt;'

## OppositeBooleanConverter
Converts a boolean to the opposite value.

## PathToImageSourceConverter
Converts the path to an image file to a BitmapImage.

Parameter Syntax (optional):
ConverterParameter='&lt;pathToImageIfImagePathNotFound&gt;|&lt;pathToImageIfImagePathErrors&gt;'

Default "Image Not found" and "Image error" are provided, but can be overridden by either passing the path to these images in the parameter, or by
setting them in the code-behind as follows:

```cs
PathToImageSourceConverter.ImageNotAvailableImage = new Uri("pack://application:,,,/RussJudge.WPFValueConverters;component/Resources/ImageNotAvailable.png", UriKind.RelativeOrAbsolute);
PathToImageSourceConverter.ImageErrorImage = new Uri("pack://application:,,,/RussJudge.WPFValueConverters;component/Resources/ImageError.png", UriKind.RelativeOrAbsolute);
```

## SecondsToTimeSpanConverter
Converts a number of seconds (type double) to a TimeSpan and formats it based on the parameter passed and culture.

Parameter Syntax (optional):
ConverterParameter='&lt;StandardDate/timeFormatCode&gt;'


## StringReplacementConverter
Replace all occurrences of a part of a string to another string.

Parameter Syntax:
ConverterParameter='&lt;stringToMatch&gt;|&lt;stringToReplaceTo&gt;'

## ValueMatchToAnimatedBrushConverter
Converts a value to a brush based on matching on the parameter.  The value is converted to a string (.ToString()) to perform the match.


Parameter Syntax:
ConverterParameter='&lt;operator&gt;|&lt;comparisonValueMatch&gt;|&lt;brushOnTrue&gt;|&lt;brushOnFalse&gt;'

## ValueMatchToBooleanConverter
Convers a value to a boolean based on matching on the parameter.  The value is converted to a string (.ToString()) to perform the match.


Parameter Syntax:
ConverterParameter='&lt;operator&gt;|&lt;comparisonValueMatch&gt;|&lt;booleanIfMatch&gt;|&lt;booleanOnNotMatch&gt;'

## ValueMatchToVisibilityConverter
Converts a value to visibility based on matching on the parameter.  The value is converted to a string (.ToString()) to perform the match.


Parameter Syntax:
ConverterParameter='&lt;operator&gt;|&lt;comparisonValueMatch&gt;|&lt;visibilityOnTrue&gt;|&lt;visibilityOnFalse&gt;'

# Addendum

## Parameter delimiters

Multiple Converter parameters are delimited by "|".  Brush definition parameters are delimited by semi-colon (";").

## Brush animation parameters and syntax
Parameters are case-insensitive.

Example: FROMCOLOR=Red;TOCOLOR=Blue;REPEATCOUNT=Forever;DURATION=1000;AUTOREVERSE=True

| Setting | Description |
| - | - |
| DEFAULT | Set brush to default value.  No other parameters can be set. |
| COLOR=&lt;value&gt; | Sets the brush to a solid color.  All other parameters are ignored. |
| FROMCOLOR=&lt;value&gt; | Sets the starting color for an animated brush. |
| TOCOLOR=&lt;value&gt; | Sets the ending color for an animated brush. |
| REPEATCOUNT=&lt;value&gt; | The number of times to repeat the animation.  Set to "Forever" to repeat forever. |
| AUTOREVERSE=&lt;value&gt; | Whether or not to auto-reverse the animation.  Valid values are "True" and "False". |

## Comparison operators

An operator will always be followed by the comparison value, such that it will work as &lt;boundValue&gt; &gtl;operator&gt; &lt;comparisonValue&gt;,
where &lt;operator&gt; and &lt;comparisonValue&gt; are set by ConverterParameter='&lt;operator&gt;|&lt;comparisonValue&gt;'.

Valid operators:

| Operator | Description |
| - | - |
| &lt; (or '&amp;lt;') | Bound value less than comparison value |
| &lt;= (or '&amp;lt;=') | Bound value less than or equal to comparison value |
| &gt; (or '&amp;gt;') | Bound value greater than comparison value |
| &gt;= (or '&amp;gt;=') | Bound value greater than or equal to comparison value |
| = | Bound value equal to comparison value |
| != | Bound value not equal to comparison value |

## Math operators

As with comparison operators, a matho operator will always be followed by a numeric value to apply to the bound value.  The bound value must be numeric.

For bitwise operators, the bound value will be converted to a long before applying the operator and the parameter value.  For math operators, the value is converted to a double
before applying the paramter value.

Valid operators:

| Operator | Description |
| - | - |
| + | Add to the bound value |
| - | Subtract from the bound value |
| * | Multiply to the bound value |
| / | divide from the bound value |
| % | return the modulo of the bound value and parameter |
| pow | return the power of the parameter to the bound value |
| abs | return the absolute value of the bound value (adjustment value parameter is ignored) |
| sin | return the sine of the bound value (adjustment value parameter is ignored) |
| sinh | return the hyperbolic sine of the bound value (adjustment value parameter is ignored) |
| cos | return the cosine of the bound value (adjustment value parameter is ignored) |
| cosh | return the hyperbolic cosine of the bound value (adjustment value parameter is ignored) |
| cbrt | return the cube root of the bound value (adjustment value parameter is ignored) |
| min | return the smaller of the bound value versus the adjustment parameter value |
| max | return the smaller of the bound value versus the adjustment parameter value |
| acos | return the angle whose cosine is the bound value (adjustment value parameter is ignored) |
| acosh | return the angle whose hyperbolic cosine is the bound value (adjustment value parameter is ignored) |
| asin | return the angle whose sine is the bound value (adjustment value parameter is ignored) |
| asinh | return the angle whose hyperbolic sine is the bound value (adjustment value parameter is ignored) |
| tan | return the tangent of the bound value (adjustment value parameter is ignored) |
| tanh | return the hyperbolic tangent of the bound value (adjustment value parameter is ignored) |
| atan | return the angle whose tangent is the bound value (adjustment value parameter is ignored) |
| atanh | return the angle whose hyperbolic tangent is the bound value (adjustment value parameter is ignored) |
| atan2 | return the angle whose tangent is the quotent between the bound value and the adjustment value parameter |
| ceiling | returns the smallest integral greater than or equal to the bound value (adjustment value parameter is ignored) |
| floor | returns the largest integral less than or equal to the bound value (adjustment value parameter is ignored) |
| round | returns the bound value rounded by to the number of decimal places specified by the adjustment value parameter |
| sqrt | returns the square root of the bound value (adjustment value parameter is ignored) |
| log | returns the logarithm of the bound value where the base value is the adjustment value. |
| &amp; | returns a bitwise "and" operation with the adjustment value |
| \ | returns a bitwise "or" operation with the adjustment value. |
| ^ | returns a bitwise "xor" operation with the adjustment value. |
| &lt;&lt; (or &amp;lt;&amp;lt;) | left-shift the bound value by the adjustment value |
| &gt;&gt; (or &amp;gt;&amp;gt;) | right-shift the bound value by the adjustment value |
| &gt;&gt;&gt; (or &amp;gt;&amp;gt;&amp;gt;) | unsigned right-shift the bound value by the adjustment value |
