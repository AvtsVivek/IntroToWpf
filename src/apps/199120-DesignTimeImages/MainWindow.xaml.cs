using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DesignTimeImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageEx.Source = new BitmapImage(new Uri(@"/images/RuntimePicture.png", UriKind.Relative));
        }
    }
}
