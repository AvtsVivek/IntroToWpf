using BasicMvvmHWinContentRendered.ViewModels;
using System;
using System.Windows;
using System.Windows.Interop;

namespace BasicMvvmHWinContentRendered.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // You can use the ContentRendered event to ensure the window handle is valid
            // Or you can override OnContentRendered method
            // this.ContentRendered += MainWindow_ContentRendered;
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            var hWnd = new WindowInteropHelper(this).Handle.ToString();
            if (this.DataContext is MainWindowViewModel vm)
            {
                vm.HWnd = hWnd;
            }
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            var hWnd = new WindowInteropHelper(this).Handle.ToString();
            // hWnd is now valid
            if (this.DataContext is MainWindowViewModel vm)
            {
                vm.HWnd = hWnd;
            }
        }
    }
}
