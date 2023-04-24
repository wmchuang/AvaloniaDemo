using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace UserControlDemo.Convers
{
    public class StringToImageSourceConverter : IValueConverter
    {
        #region Converter

        private IAssetLoader _assetLoader;

        public StringToImageSourceConverter()
        {
            _assetLoader = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string path = (string)value;
                return new Bitmap(_assetLoader.Open(new Uri("avares://UserControlDemo/Assets/" + path)));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}