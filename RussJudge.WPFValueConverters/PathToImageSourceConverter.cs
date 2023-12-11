using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RussJudge.WPFValueConverters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class PathToBitmapImageConverter : IValueConverter
    {
        public static Uri ImageNotAvailableImage { get; set; } = new Uri("pack://application:,,,/RussJudge.WPFValueConverters;component/Resources/ImageNotAvailable.png", UriKind.RelativeOrAbsolute);
        public static Uri ImageErrorImage { get; set; } = new Uri("pack://application:,,,/RussJudge.WPFValueConverters;component/Resources/ImageError.png", UriKind.RelativeOrAbsolute);

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string filePath)
            {
                Uri imageNotAvailable = ImageNotAvailableImage;
                Uri imageError = ImageErrorImage;

                if (parameter is string parms)
                {
                    var parm = parms.Split('|');
                    imageNotAvailable = new Uri(parm[0]);
                    if (parm.Length > 1)
                    {
                        imageError = new Uri(parm[1]);
                    }
                }
                Uri? imageUri = null;

                if (filePath.IndexOf(':') == 1)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        imageUri = new Uri(filePath, UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        imageUri = imageNotAvailable;
                    }
                }
                if (imageUri == null)
                {
                    imageUri = new Uri(filePath, UriKind.RelativeOrAbsolute);
                }

                try
                {
                    BitmapImage image = new();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;

                    image.UriSource = imageUri;
                    image.EndInit();
                    image.Freeze();
                    return image;
                }
                catch (Exception ex)
                {
                    // Handle exception if loading image fails
                    Console.WriteLine($"Error loading image from path: {ex.Message}");
                    BitmapImage image = new();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = imageError;
                    image.EndInit();
                    image.Freeze();
                    return image;
                }

            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
