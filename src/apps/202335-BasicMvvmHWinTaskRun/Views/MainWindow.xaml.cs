using BasicMvvmHWinTaskRun.ViewModels;
using System.Windows;
using System.Windows.Interop;

namespace BasicMvvmHWinTaskRun.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SourceInitialized += (_, _) =>
            {
                if (DataContext is MainWindowViewModel vm)
                    vm.HWnd = new WindowInteropHelper(this).Handle.ToString();
            };
        }
    }
}
