using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using static Anaglyphizer.Util;

namespace Anaglyphizer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap bitmapImage;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Open image";
            openFileDialog1.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog1.Multiselect = false;

            bool? userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == true)
            {
                bitmapImage = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = ConvertBitmapToBitmapImage(GetAnaglyphFromStereopair(bitmapImage, Algorythm.TrueAnaglyph));
            image.Source = img;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = ConvertBitmapToBitmapImage(GetAnaglyphFromStereopair(bitmapImage, Algorythm.ColorAnaglyph));
            image.Source = img;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = ConvertBitmapToBitmapImage(GetAnaglyphFromStereopair(bitmapImage, Algorythm.HalfColorAnaglyph));
            image.Source = img;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = ConvertBitmapToBitmapImage(GetAnaglyphFromStereopair(bitmapImage, Algorythm.OptimizedAnaglyph));
            image.Source = img;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = ConvertBitmapToBitmapImage(GetAnaglyphFromStereopair(bitmapImage, Algorythm.GrayAnaglyph));
            image.Source = img;
        }
    }
}
