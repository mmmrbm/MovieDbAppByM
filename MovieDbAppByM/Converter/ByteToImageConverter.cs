using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MovieDbAppByM.Converter
{
    /// <summary>
    /// Converter for array of <see cref="byte" /> to <see cref="BitmapImage" /> to be used in XAML UI.
    /// </summary>
    public class ByteToImageConverter : IValueConverter
    {
        /// <summary>
        /// Logic to convert byte[] to BitmapImage.
        /// Based ono https://stackoverflow.com/questions/11771223/loading-the-source-of-a-bitmapimage-in-wpf
        /// </summary>
        /// <param name="imageByteArray">The array of <see cref="byte"/></param>
        /// <returns>Constructed <see cref="BitmapImage"/> from parameter.</returns>
        private BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageByteArray))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
            }
            return bitmap;
        }

        /// <inheritdoc <see cref="IMultiValueConverter"> />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage img = new BitmapImage();
            if (value != null)
            {
                img = this.ConvertByteArrayToBitMapImage(value as byte[]);
            }
            return img;
        }

        /// <inheritdoc <see cref="IMultiValueConverter"> />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
