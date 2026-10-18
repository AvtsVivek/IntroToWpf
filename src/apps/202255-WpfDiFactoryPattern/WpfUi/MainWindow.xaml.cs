using DataLibrary;
using System.Windows;
using WpfUi.Utilities;

namespace WpfUi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IAbstactFactory<ChildForm> _abstactFactory;
    // private readonly ChildForm _childForm;

    public MainWindow(IDataAccess dataAccess, IAbstactFactory<ChildForm> abstactFactory /*, ChildForm childForm*/)
    {
        DataContext = dataAccess;
        InitializeComponent();
        _abstactFactory = abstactFactory;
        //_childForm = childForm;
    }

    private void OpenChildForm_Click(object sender, RoutedEventArgs e)
    {
        var form = _abstactFactory.Create();
        form.Show();
        // _childForm.Show();
    }
}