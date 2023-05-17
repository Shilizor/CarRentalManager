using CarRentalManager.Model;
using CarRentalManager.Utillites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _windowService.ShowMainWindow();
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
