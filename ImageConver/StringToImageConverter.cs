using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace ImageConver
{
    /// <summary>
    /// 图片资源路径转图片
    /// </summary>
    public class StringToImageConverter : IValueConverter
    {
        public static StringToImageConverter Instance { get; } = new();

        private static string prefix = "avares://";

        /// <summary>
        /// 存储当前程序内嵌图片资源（用于节省内存）
        /// </summary>
        private Dictionary<string, Bitmap> _bitmaps;

        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;
            if (path == null) return null;

            if (_bitmaps == null)
                _bitmaps = new Dictionary<string, Bitmap>(0);

            if (_bitmaps.TryGetValue(path, out var convert))
                return convert;

            var bitmap = LoadImage(path);
            _bitmaps.Add(path, bitmap);

            return bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public static Bitmap LoadImage(string path, bool innerDomain = false)
        {
            try
            {
                if (path.StartsWith(prefix))
                {
                    return LoadAssetImage(path);
                }

                if (innerDomain)
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + path;
                }

                return LoadImagePath(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load asset image: {ex.Message}");
            }

            return null;
        }

        private static Bitmap LoadAssetImage(string path)
        {
            //path = "avares://AvaloniaMinDemo/Images/nc_icon1.png";
            var assets = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();
            return new Bitmap(assets.Open(new Uri(path)));
        }

        private static Bitmap LoadImagePath(string path)
        {
            Bitmap bitmap = null;
            using (var stream = File.OpenRead(path))
            {
                bitmap = new Bitmap(stream);
            }

            return bitmap;
        }

        #endregion
    }
}