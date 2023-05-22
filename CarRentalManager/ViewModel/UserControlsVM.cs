using CarRentalManager.Model.DataManager;
using CarRentalManager.Model.DataManager.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRentalManager.Utillites;

namespace CarRentalManager.ViewModel
{
    public class UserControlsVM : ViewModelBase
    {

        #region Validates

        public string SearchTB { get; set; }

        private static decimal Money = Convert.ToDecimal(DBMethods.GetAllBanks().FirstOrDefault(u => u.UserID == DBMethods.GetUser(Settings.Default.Login).Id).Sum);
        private static ObservableCollection<Order> orders = new ObservableCollection<Order>(DBMethods.GetAllOrder().Where(u => u.UserID == DBMethods.GetUser(Settings.Default.Login).Id).ToList());
        private static ObservableCollection<Car> Cars = new ObservableCollection<Car>(DBMethods.GetAllCars());

        private string Balancestg = $"Ваш баланс: {Math.Round(Money, 2)}";

        public string LoginUser { get; set; } = DBMethods.GetUser(Settings.Default.Login).Login;
        public string EmailUser { get; set; } = $"Email: {DBMethods.GetUser(Settings.Default.Login).Email}";
        public string StatusUser { get; set; } = DBMethods.GetUser(Settings.Default.Login).Status;


        #endregion

        #region Commands
        public ICommand AddOrdercmd { get; set; }
        #endregion

        #region Methods
        private void addOrder()
        {
            var order = new Order
            {
                DataTime = DateTime.Now,
                status = "Готово",
                UserID = DBMethods.GetUser(Settings.Default.Login).Id
            };

            DBMethods.AddOrder(order);
            orders.Add(order);
            OnPropertyChanged("AllOrdersUser");
        }
        public ObservableCollection<Order> AllOrdesUser
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged("AllOrdesUser");
            }
        }
        public ObservableCollection<Car> AllCars
        {
            get
            {
                return Cars;
            }
            set
            {
                Cars = value;
                OnPropertyChanged("AllCars");
            }
        }
        public string TotalMoney 
        { 
            get
            {
                return Balancestg;
            }
            set
            {
                Balancestg = value;
                OnPropertyChanged("TotalMoney");
            }
        }
        #endregion



        public UserControlsVM() 
        {
            AddOrdercmd = new RelayCommand(obj => addOrder());
        }
    }
}
