using CarRentalManager.Model;
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
    public class MainRegVM
    {
        public string UserLogin { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPasswordReward { get; set; }

        IWindowService _windowService;
        public ICommand CloseWindows { get; set; }
        public ICommand ShowAuthWindowCmd { get; set; }
        public ICommand checkcmd { get; set; }

        private void ShowAuthWindow()
        {
            _windowService.ShowAuthWindow();
        }

        private void check()
        {
            if(UserLogin == null || UserLogin == " ")
            {
                MessageBox.Show("Вы не ввели login");
                return;
            }
            if (UserEmail == null || UserEmail == " ")
            {
                MessageBox.Show("Вы не ввели Email");
                return;
            }
            if (UserPassword == null || UserPassword == " ")
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }
            if (UserPasswordReward == null || UserPasswordReward == " " || UserPasswordReward != UserPassword)
            {
                MessageBox.Show("Введенный пароль не совпадает");
                return;
            }
            MessageBox.Show($"Ваш Логин: {UserLogin}\nВаш пароль: {UserPassword}\nВаш Email: {UserEmail}");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            window.Close();
            _windowService.ShowMainWindow();
        }
        private void CloseWindow()
        {
            _windowService.CloseWindow();
        }
        public MainRegVM(IWindowService service) 
        {
            _windowService = service;

            CloseWindows = new RelayCommand(obj => CloseWindow());
            ShowAuthWindowCmd = new RelayCommand(obj => ShowAuthWindow());
            checkcmd = new RelayCommand(obj => check());
        }
    }
}
