using CarRentalManager.Model;
using CarRentalManager.Model.DataManager;
using CarRentalManager.Utillites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarRentalManager.ViewModel
{
    public class MainAuthVM
    {
        IWindowService _windowService;
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public ICommand CloseWindows { get; set; }
        public ICommand OpenRegWindowCmd { get; set; }
        public ICommand OpenMainWindowCmd { get; set; }

        private void OpenRegWindow()
        {
            _windowService.ShowRegWindow();
        }
        private void OpenMainWindow()
        {
            if(UserLogin == "" || UserLogin == null)
            {
                MessageBox.Show("Вы не ввели логин");
                return;
            }
            if (UserPassword == "" || UserPassword == null)
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }
            if (DBMethods.IsCorrectLoginPassword(UserLogin, UserPassword) == false)
            {
                Settings.Default.Login = UserLogin;
                _windowService.ShowMainWindow();
            }
            else
            {
                MessageBox.Show("Пользователь не существует");
                return;
            }
        }
        private void CloseWindow()
        {
            _windowService.CloseWindow();
        }

        public MainAuthVM(IWindowService service) 
        {
            _windowService = service;

            CloseWindows = new RelayCommand(obj => CloseWindow());
            OpenMainWindowCmd = new RelayCommand(obj => OpenMainWindow());
            OpenRegWindowCmd = new RelayCommand(obj => OpenRegWindow());

            UserLogin = "Login";
        }
    }
}
