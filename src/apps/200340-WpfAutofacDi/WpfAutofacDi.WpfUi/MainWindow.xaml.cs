using System.Windows;
using WpfAutofacDi.DataLibrary;

namespace WpfAutofacDi.WpfUi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IDataAccess dataAccess)
    {
        DataContext = dataAccess;
        InitializeComponent();
    }
}