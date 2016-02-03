using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AForge.Imaging.Filters;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Interop;
using static Anaglyphizer.Constants;

namespace Anaglyphizer
{
    public static class Util
    {
        private static Bitmap leftImage;
        private static Bitmap rightImage;

        public enum Algorythm
        {
            TrueAnaglyph,
            GrayAnaglyph,
            ColorAnaglyph,
            HalfColorAnaglyph,
            OptimizedAnaglyph
        };

        public static Bitmap GetAnaglyphFromStereopair(Bitmap stereopair, Algorythm algorythm)
        {
            DevideStereopairOnTwoImages(stereopair);
            StereoAnaglyph filter = new StereoAnaglyph();
            filter.OverlayImage = rightImage;

            switch (algorythm)
            {
                case Algorythm.ColorAnaglyph:
                    return filter.Apply(leftImage,
                        COLOR_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
                        COLOR_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);

                case Algorythm.TrueAnaglyph:
                    return filter.Apply(leftImage,
                        TRUE_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
                        TRUE_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);

                case Algorythm.OptimizedAnaglyph:
                    return filter.Apply(leftImage,
                        OPTIMIZED_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
                        OPTIMIZED_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);

                case Algorythm.HalfColorAnaglyph:
                    return filter.Apply(leftImage,
                        HALF_COLOR_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
                        HALF_COLOR_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);

                case Algorythm.GrayAnaglyph:
                    return filter.Apply(leftImage,
                        GRAY_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
                        GRAY_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);

                default:
                    return filter.Apply(leftImage,
               COLOR_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX,
               COLOR_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX);
            }
        }

        private static void DevideStereopairOnTwoImages(Bitmap stereopair)
        {
            var halfW = stereopair.Width / 2;
            leftImage = GetRectanglePartOfImage(stereopair, new RectangleF(0, 0, halfW, stereopair.Height));
            rightImage = GetRectanglePartOfImage(stereopair, new RectangleF(halfW, 0, halfW, stereopair.Height));
        }

        private static Bitmap GetRectanglePartOfImage(Bitmap image, RectangleF rectangle)
        {
            return image.Clone(rectangle, image.PixelFormat);
        }

        public static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Bmp);
            memoryStream.Position = 0;

            BitmapImage convertedBitmapImage = new BitmapImage();
            convertedBitmapImage.BeginInit();
            convertedBitmapImage.StreamSource = memoryStream;
            convertedBitmapImage.EndInit();

            return convertedBitmapImage;
        }

        public static Color Multiply(this Color sourceColor, double[,] filterMatrix)
        {
            Double red = 0, green = 0, blue = 0;
            red += filterMatrix[0, 0] * sourceColor.R + filterMatrix[0, 1] * sourceColor.G + filterMatrix[0, 2] * sourceColor.B;
            green += filterMatrix[1, 0] * sourceColor.R + filterMatrix[1, 1] * sourceColor.G + filterMatrix[1, 2] * sourceColor.B;
            blue += filterMatrix[2, 0] * sourceColor.R + filterMatrix[2, 1] * sourceColor.G + filterMatrix[2, 2] * sourceColor.B;
            return Color.FromArgb((int)Math.Round(red), (int)Math.Round(green), (int)Math.Round(blue));
        }

        public static Color Plus(this Color leftColor, Color rightColor)
        {
            return Color.FromArgb(leftColor.R + rightColor.R, leftColor.G + rightColor.G, leftColor.B + rightColor.B);
        }
    }
}
