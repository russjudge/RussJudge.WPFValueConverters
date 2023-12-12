# RussJudge.WPFValueConverters

A collection of ValueConverters that I've built over the years.

All these are ValueConverters to be added to the Xaml of a WPF control.

For examples on how to use these ValueConverters, please see the example project on the Github repository page at <https://github.com/russjudge/RussJudge.WPFValueConverters>.

## BooleanToBrushAnimationConverter

This converter will take a boolean value and generate a System.Windows.Media.SolidColorBrush.  Based on the parameters provided, the brush can be animated.
See the addendum to this readme for details on these parameters.

## BytesToMBFormatter

This converts an int64 number into a string formatted by culture.  It assumes the number represents bytes and divides by factors of 1024 to 
represent KB, MB, GB, TB, PB, or EB so that the result is a number greater than 1 and less than 1,024.

For example, if the number is 248332132, you will convert this to 236.0MB.


## CurrencyFormatter
This converter takes a number and formats it to a currency value based on the culture.

## DateFormatter
This converter takes a datetime value and formats it to a human-readable format based on the culture or using the format passed as the converter parameter.


## FalseBoolToVisibilityConverter
Converts a boolean value to Visibility, false being Visible, while true is Collapsed.  This is to produce the opposite behavior to BooleanToVisibilityConverter.

## FullFilePathToNameConverter
This converts a string that represents the full path to a file.  The result will be simply the file name excluding the path to that file.

## NullToAnimatedBrushConverter
Converts a nullable object to a SolidColorBrush.  

## NullToVisibilityConverter
Converts a nullable objects to Visibility.

## NumberFormatter
Formats a number.

## NumericAdjustmentConverter
Adds a value to a number, set by the parameter.

## NumericComparisonToBrushAnimationConverter
Compares a value to a number in the parameter and converts to a brush.

## NumericComparisonToVisibilityConverter
Compares a value to a number in the parameter and converts to visibility.

## OppositeBooleanConverter
Converts a boolean to the opposite value.

## PathToImageSourceConverter
Converts the path to an image file to a BitmapImage.

## SecondsToTimeSpanConverter
Converts a number of seconds to a TimeSpan and formats it.

## StringReplacementConverter
Replace a part of a string to another string.

## ValueMatchToAnimatedBrushConverter

## ValueMatchToVisibilityConverter


# Addendum

## Brush animation parameters and syntax


## Comparison operators