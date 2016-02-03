using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Anaglyphizer
{
    public static class Constants
    {
        public static int FILTER_ARRAY_SIZE = 3;

        public static double[,] TRUE_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX = { { 0.299, 0.587, 0.114},
                                                 { 0, 0, 0 },
                                                 { 0, 0, 0 } };
        public static double[,] TRUE_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX = { { 0, 0, 0 },
                                                 { 0, 0, 0 },
                                                 { 0.299, 0.587, 0.114} };

        public static double[,] COLOR_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX = { { 1, 0, 0},
                                                 { 0, 0, 0 },
                                                 { 0, 0, 0 } };
        public static double[,] COLOR_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX = { { 0, 0, 0 },
                                                 { 0, 1, 0 },
                                                 { 0, 0, 1 } };

        public static double[,] HALF_COLOR_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX = { { 0.299, 0.587, 0.114},
                                                 { 0, 0, 0 },
                                                 { 0, 0, 0 } };
        public static double[,] HALF_COLOR_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX = { { 0, 0, 0 },
                                                 { 0, 1, 0 },
                                                 { 0, 0, 1 } };

        public static double[,] OPTIMIZED_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX = { { 0, 0.7, 0.3},
                                                 { 0, 0, 0 },
                                                 { 0, 0, 0 } };
        public static double[,] OPTIMIZED_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX = { { 0, 0, 0 },
                                                 { 0, 1, 0 },
                                                 { 0, 0, 1} };

        public static double[,] GRAY_ANAGLYPH_LEFT_IMAGE_FILTER_MATRIX = { { 0.299, 0.587, 0.114},
                                                 { 0, 0, 0 },
                                                 { 0, 0, 0 } };
        public static double[,] GRAY_ANAGLYPH_RIGHT_IMAGE_FILTER_MATRIX = { { 0, 0, 0 },
                                                { 0.299, 0.587, 0.114},
                                                { 0.299, 0.587, 0.114} };
    }
}
