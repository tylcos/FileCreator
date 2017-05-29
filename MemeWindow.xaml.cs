using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace File_Creator
{
    /// <summary>
    /// Interaction logic for MemeWindow.xaml
    /// </summary>
    public partial class MemeWindow : Window
    {
        public MemeWindow()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            Random rand = new Random();
            string imagePath = @"Pictures/meme" + rand.Next(1, 10) + ".jpg";
            ImageWindow.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }
    }
}
