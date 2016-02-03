using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Anaglyphizer.Constants;

namespace Anaglyphizer
{
    public class StereoAnaglyph
    {
        private Bitmap overlayImage;

        public Bitmap OverlayImage
        {
            get { return overlayImage; }
            set { overlayImage = value; }
        }

        public Bitmap Apply(Bitmap image, double[,] leftFilter, double[,] rightFilter)
        {
            if (EqualsImagesDimensions(OverlayImage, image))
            {
                Bitmap resultImage = new Bitmap(image.Width, image.Height);
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        resultImage.SetPixel(x, y, EvaluatePixelColor(overlayImage.GetPixel(x, y),
                            image.GetPixel(x, y),
                            leftFilter,
                            rightFilter));
                    }
                }
                return resultImage;
            }
            return OverlayImage;
        }

        private bool EqualsImagesDimensions(Bitmap leftImage, Bitmap rightImage)
        {
            return leftImage.Width == rightImage.Width && leftImage.Height == rightImage.Height;
        }

        private Color EvaluatePixelColor(Color leftColor, Color rightColor, double[,] leftFilter, double[,] rightFilter)
        {
            return leftColor.Multiply(leftFilter).Plus(rightColor.Multiply(rightFilter));
        }
    }
}
