using System;
using System.Drawing;

namespace Dewey.Drawing
{
    /// <summary>
    /// Extension methods for Bitmap type
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Create an empty bitmap
        /// </summary>
        public static Bitmap EmptyBitmap {
            get {
                var result = new Bitmap(1, 1);

                var gfx = Graphics.FromImage(result);

                gfx.FillRectangle(Brushes.Transparent, 0, 0, 1, 1);

                return result;
            }
        }

        /// <summary>
        /// Get the bytes representing an empty bitmap
        /// </summary>
        public static byte[] EmptyBitmapBytes {
            get {
                var result = new Bitmap(1, 1);

                var gfx = Graphics.FromImage(result);

                gfx.FillRectangle(Brushes.Transparent, 0, 0, 1, 1);

                return (byte[])(new ImageConverter()).ConvertTo(result, typeof(byte[]));
            }
        }

        /// <summary>
        /// Get the bytes for a bitmap
        /// </summary>
        /// <param name="value">The bitmap</param>
        /// <returns>The bitmap bytes</returns>
        public static byte[] GetBytes(this Bitmap value)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            return (byte[])(new ImageConverter()).ConvertTo(value, typeof(byte[]));
        }
    }
}
