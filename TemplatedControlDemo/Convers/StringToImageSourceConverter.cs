using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Platform;

namespace TemplatedControlDemo.Convers
{
    public class StringToImageSourceConverter : IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string path = (string)value;
                // if (!string.IsNullOrEmpty(path))
                // {
                //     // path = "avares://UserControlDemo/Assets/video1.png";
                //     var assets = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();
                //     return new Bitmap(assets.Open(new Uri(path)));
                // }
                // else
                // {
                //     return null;
                // }

                Bitmap bitmap = null;
                if (!string.IsNullOrEmpty(path))
                {
                    using (var stream = File.OpenRead(path))
                    {
                        bitmap = new Bitmap(stream);
                    }

                    return bitmap;
                }

                return null;
            }
            catch (Exception e)
            {
                return "avares://UserControlDemo/Assets/video.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}