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
using System.Windows.Shapes;
using CarRentalManager.Model;
using CarRentalManager.ViewModel;

namespace CarRentalManager.Views
{
    /// <summary>
    /// Логика взаимодействия для MainAuth.xaml
    /// </summary>
    public partial class MainAuth : Window
    {
        public MainAuth()
        {
            InitializeComponent();
            IWindowService service = new WindowService();
            DataContext = new MainAuthVM(service);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Button_Click_1(object sender, RoutedEventArgs e) => this.Close();
    }
}
