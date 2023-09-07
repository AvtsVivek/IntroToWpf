using DataLibrary;
using System.Windows;


namespace WpfUi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ChildForm _childForm { get; set; }
    public MainWindow(IDataAccess dataAccess, ChildForm childForm)
    {

        DataContext = dataAccess;
        _childForm = childForm;
        InitializeComponent();
    }

    private void OpenChildForm_Click(object sender, RoutedEventArgs e)
    {
        _childForm.Show();
    }
}