using Autofac;
using System.Windows;
using WpfAutofacDi.DataLibrary;

namespace WpfAutofacDi.WpfUi;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IContainer _container;
    public App()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<MainWindow>().AsSelf();
        builder.RegisterType<DataAccess>().As<IDataAccess>();
        _container = builder.Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = _container.Resolve<MainWindow>();
        MainWindow = window;
        window.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();
        base.OnExit(e);
    }
}
