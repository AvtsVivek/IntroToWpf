using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using System.Windows;

namespace BasicMahAppsMetroOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.SaveWindowPosition = true;
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
        }

        private void DeployCupCakes(object sender, RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }

        private async void ClickMeOnClick(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Title Template Test", "Thx for using MahApps.Metro!!!");
        }
    }
}
