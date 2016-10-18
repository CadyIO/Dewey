using System;
using System.Drawing;

namespace Dewey.Drawing
{
    public static class BitmapExtensions
    {
        public static Bitmap EmptyBitmap {
            get {
                var result = new Bitmap(1, 1);

                var gfx = Graphics.FromImage(result);

                gfx.FillRectangle(Brushes.Transparent, 0, 0, 1, 1);

                return result;
            }
        }

        public static byte[] EmptyBitmapBytes {
            get {
                var result = new Bitmap(1, 1);

                var gfx = Graphics.FromImage(result);

                gfx.FillRectangle(Brushes.Transparent, 0, 0, 1, 1);

                return (byte[])(new ImageConverter()).ConvertTo(result, typeof(byte[]));
            }
        }

        public static byte[] GetBytes(this Bitmap value)
        {
            if (value == null) {
                throw new ArgumentException(nameof(value));
            }

            return (byte[])(new ImageConverter()).ConvertTo(value, typeof(byte[]));
        }
    }
}
