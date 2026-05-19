using System.Windows;

namespace IgnorableAttributeIntro
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

        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            firstButton.Content = "Thanks";
        }
    }
}
