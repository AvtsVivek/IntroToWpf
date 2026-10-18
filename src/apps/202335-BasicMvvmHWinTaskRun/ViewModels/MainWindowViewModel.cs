using System.Diagnostics;

namespace BasicMvvmHWinTaskRun.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        public string Number { get; set; } = "One";
        public string ProcessId { get; set; }
        public string _hWnd = string.Empty;

        public string HWnd
        {
            get
            {
                return _hWnd;
            }
            set
            {
                _hWnd = value;
                OnPropertyChanged(nameof(HWnd));
            }
        }

        public MainWindowViewModel()
        {
            ProcessId = Process.GetCurrentProcess().Id.ToString();
            // At this point, right at the start of the wpf app, the process is still starting.
            // The Process Id is ready, but the Main Window Handle of the wpf app is still not ready.
            // The following will return 0.
            // So the following assignment is useless. 
            // HWnd = Process.GetCurrentProcess().MainWindowHandle.ToString();

            // We need to wait some time till the window handle is ready.
            // So the following is needed.
            //Task.Run(async () =>
            //{
            //    await GetAndAssignWindowHandle();
            //});
        }

        // Task.Delay(1000) is a timing guess:
        // the window might be ready sooner or later.
        // In WPF, use the window’s SourceInitialized event,
        // which fires when its native window handle has been created.
        // Look  at the MainWindow.xaml.cs file for an example of how to do this.
        //private async Task GetAndAssignWindowHandle()
        //{
        //    await Task.Delay(1000);
        //    HWnd = Process.GetCurrentProcess().MainWindowHandle.ToString();
        //}

    }
}
