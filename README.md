# RussJudge.WPFValueConverters

A collection of ValueConverters that I've built over the years.

All these are ValueConverters to be added to the Xaml of a WPF control.

For examples on how to use these ValueConverters, please see the example project on the Github repository page at <https://github.com/russjudge/RussJudge.WPFValueConverters>.

## BooleanToBrushAnimationConverter

This converter will take a boolean value and generate a System.Windows.Media.SolidColorBrush.  Based on the parameters provided, the brush can be animated.
See the addendum to this readme for details on these parameters.

Parameter syntax: 

ConverterParameter='&lt;boolValueToMatch-default true&gt;|&lt;brush definition on match&gt;|&lt;brush definiton on mismatch&gt;'

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


## NullToVisibilityConverter
Converts a nullable objects to Visibility, based on parameters passed.

Parameter Syntax:

ConverterParameter='&lt;VisibilityIfNull&gt;|&lt;VisibilityIfNotNull&gt;'

## NumberFormatter
Formats a number, based on the culture and parameters passed.

Parameter Syntax (optional):

ConverterParameter='<Standard number format codes>'


## NumericAdjustmentConverter
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

An operator will always be followed by the comparison value, such that it will work as <boundValue> <operator> <comparisonValue>,
where <operator> and <comparisonValue> are set by ConverterParameter='&lt;operator&gt;|&lt;comparisonValue&gt;'.

Valid operators:

| Operator | Description |
| - | - |
| < (or '&amp;lt;') | Bound value less than comparison value |
| <= (or '&amp;lt;=') | Bound value less than or equal to comparison value |
| > (or '&amp;gt;') | Bound value greater than comparison value |
| >= (or '&amp;gt;=') | Bound value greater than or equal to comparison value |
| = | Bound value equal to comparison value |
| != | Bound value not equal to comparison value |
