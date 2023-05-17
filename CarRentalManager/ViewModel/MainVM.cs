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
    public class MainVM
    {
        IWindowService _windowService;
        public ICommand CloseWindows { get; set; }
        private void CloseWindow()
        {
            _windowService.CloseWindow();
        }
        public MainVM(IWindowService service) 
        { 
            _windowService = service;
            CloseWindows = new RelayCommand(obj => CloseWindow());
        }
    }
}
