# Basic Wpf App with Mvvm.

1. Reference:
https://www.technical-recipes.com/2022/navigating-between-views-in-wpf-mvvm-using-dependency-injection/

2. This example uses the ContentRendered event to ensure that the Main Window Handle is available before trying to access it. In the earlier example, BasicMvvmHWinTaskRun, we had to wait for the window handle to be ready.

```cs
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
```