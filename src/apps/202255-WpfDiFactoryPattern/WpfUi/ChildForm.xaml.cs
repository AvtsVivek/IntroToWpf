using DataLibrary;
using System.Windows;

namespace WpfUi
{
    /// <summary>
    /// Interaction logic for ChildForm.xaml
    /// </summary>
    public partial class ChildForm : Window
    {
        public ChildForm(IDataAccess dataAccess)
        {
            DataContext = dataAccess;
            InitializeComponent();
        }
    }
}
