using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Dewey.Drawing
{
    /// <summary>
    /// Extension methods for Image type
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Get the bytes for a image
        /// </summary>
        /// <param name="value">The image</param>
        /// <returns>The image bytes</returns>
        public static byte[] GetBytes(this Image value)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            return (byte[])(new ImageConverter()).ConvertTo(value, typeof(byte[]));
        }

        /// <summary>
        /// Resize an image from byte array
        /// </summary>
        /// <param name="value">The image byte array to resize</param>
        /// <param name="maxWidth">The max width to resize an image to</param>
        /// <param name="maxHeight">The max height to resize an image to</param>
        /// <returns>The resized Image</returns>
        public static Image Resize(this byte[] value, int maxWidth, int maxHeight)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            var image = GetImage(value);

            return Resize(image, maxWidth, maxHeight);
        }

        /// <summary>
        /// Get an image from a byte array
        /// </summary>
        /// <param name="value">The byte array of the image</param>
        /// <returns>The image</returns>
        public static Image GetImage(this byte[] value)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            using (var ms = new MemoryStream(value)) {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Resize an image
        /// </summary>
        /// <param name="value">The image to resize</param>
        /// <param name="maxWidth">The max width to resize an image to</param>
        /// <param name="maxHeight">The max height to resize an image to</param>
        /// <returns>The resized Image</returns>
        public static Image Resize(this Image value, int maxWidth, int maxHeight)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            var wScale = (float)maxWidth / value.Width;
            var hScale = (float)maxHeight / value.Height;

            var scale = Math.Min(wScale, hScale);

            var newWidth = (int)(scale * value.Width + 0.5f);
            var newHeight = (int)(scale * value.Height + 0.5f);

            var result = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            var gfx = Graphics.FromImage(result);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(value, 0, 0, newWidth, newHeight);

            return result;
        }

        /// <summary>
        /// Returns the proper scale factor based on the image
        /// </summary>
        /// <param name="value">The image to scale</param>
        /// <param name="maxWidth">The max width after scaling</param>
        /// <param name="maxHeight">The max height after scaling</param>
        /// <returns>Scale factor result</returns>
        public static double GetScaleFactor(this Image value, double maxWidth, double maxHeight)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            if (value.Width > maxWidth && value.Height > maxHeight) {
                if (value.Width > value.Height) {
                    return maxWidth / value.Width;
                }

                return maxHeight / value.Height;
            }

            if (value.Width > maxWidth) {
                return maxWidth / value.Width;
            }

            if (value.Height > maxHeight) {
                return maxHeight / value.Height;
            }

            return 1.0;
        }
    }
}
