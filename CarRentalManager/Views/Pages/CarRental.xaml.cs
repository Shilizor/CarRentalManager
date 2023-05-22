using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarRentalManager.ViewModel;

namespace CarRentalManager.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarRental.xaml
    /// </summary>
    public partial class CarRental : UserControl
    {
        public CarRental()
        {
            InitializeComponent();
            DataContext = new UserControlsVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
