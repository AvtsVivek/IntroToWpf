using System.Collections.Generic;
using System.Windows;

namespace DesignTimeListViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CityListView.ItemsSource = new List<City> {
                new City {
                    Country = "India", Name="Delhi"
                },
                new City {
                    Country = "Sri Lanka", Name="Colombo"
                },
                new City {
                    Country = "China", Name="Bezing"
                }
            };
        }
    }
}
