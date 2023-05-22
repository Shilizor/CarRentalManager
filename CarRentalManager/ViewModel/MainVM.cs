using CarRentalManager.Model;
using CarRentalManager.Utillites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel;
using CarRentalManager.Model.DataManager.DataModel;
using CarRentalManager.Model.DataManager;
using System.Dynamic;
using CarRentalManager.Views.Pages;

namespace CarRentalManager.ViewModel
{
    public class MainVM : ViewModelBase
    {
        #region Validates
        private IWindowService _windowService;
        private UserControl Profile;
        private UserControl CarRental;
        private UserControl Administration;
        private UserControl Setting;
        private string pageName;
        private bool _isAdmin = DBMethods.GetUser(Settings.Default.Login).Status == "Администратор" ? true : false;
        public string loginUser { get; set; } = DBMethods.GetUser(Settings.Default.Login).Login;
        public string statusUser { get; set; } = DBMethods.GetUser(Settings.Default.Login).Status;

        private Visibility _visibility = Visibility.Visible;

        private UserControl _currentPage;
        private double _frameOpacity;
        #endregion


        public ICommand ProfileCommand { get; set; }
        public ICommand CarRentalCommand { get; set; }
        public ICommand AdministrationCommand { get; set; }
        public ICommand checkAdminCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand CloseWindows { get; set; }

        #region Methods

        // Методы для открытие вкладок
        private void ProfileMethod(object obj)
        {
            checkPageName(Profile);
            SlowOpacity(Profile);
        }
        private void CarRentalMethod(object obj)
        {
            checkPageName(CarRental);
            SlowOpacity(CarRental);
        }
        private void AdministrationMethod(object obj)
        {
            checkPageName(Administration);
            SlowOpacity(Administration);

        }
        private void SettingsMethod(object obj)
        {
            checkPageName(Setting);
            SlowOpacity(Setting);

        }


        // Проверка доступа на вкладку Администрирование
        public Visibility checkVisibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }


        public string PageName
        {
            get
            {
                return pageName;
            }
            set
            {
                pageName = value;
                OnPropertyChanged("PageName");
            }
        }

        public void checkPageName(UserControl page)
        {
            if (CurrentPage != page)
            {
                switch (page)
                {
                    case CarRentalManager.Views.Pages.CarRental:
                        PageName = "Аренда автомобилей";
                        break;
                    case CarRentalManager.Views.Pages.Administration:
                        PageName = "Администрирование";
                        break;
                    case CarRentalManager.Views.Pages.Settings:
                        PageName = "Настройки";
                        break;
                    case CarRentalManager.Views.Pages.Profile:
                        PageName = "Профиль";
                        break;
                    default:
                        PageName = "Главная страница";
                        break;
                }
            }
        }

        private void checkAdminMethod()
        {
            if (_isAdmin == true)
            {
                checkVisibility = Visibility.Visible;
            }
            else
            {
                checkVisibility = Visibility.Collapsed;
            }
        }

        // Плавность открытие вкладок
        public double FrameOpacity
        {
            get
            {
                return _frameOpacity;
                OnPropertyChanged("FrameOpacity");
            }
            set
            {
                _frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

        private async void SlowOpacity(UserControl page)
        {
            await Task.Factory.StartNew(() =>
            {
                if (CurrentPage != page)
                {
                    for (double i = 1.0; i > 0.0; i -= 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(50);
                    }
                    CurrentPage = page;
                    for (double i = 0.0; i < 1.1; i += 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(50);
                    }
                }
            });

        }


        // Метод открытие вкладок
        public UserControl CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        private void CloseWindow()
        {
            _windowService.CloseWindow();
        }
        #endregion
        public MainVM(IWindowService service)
        {
            _windowService = service;
            Profile = new CarRentalManager.Views.Pages.Profile();
            CarRental = new CarRentalManager.Views.Pages.CarRental();
            Administration = new CarRentalManager.Views.Pages.Administration();
            Setting = new CarRentalManager.Views.Pages.Settings();

            ProfileCommand = new RelayCommand(ProfileMethod);
            CarRentalCommand = new RelayCommand(CarRentalMethod);
            AdministrationCommand = new RelayCommand(AdministrationMethod);
            SettingsCommand = new RelayCommand(SettingsMethod);

            FrameOpacity = 1;
            CurrentPage = CarRental;
            PageName = "Аренда автомобилей";
            checkAdminMethod();
            CloseWindows = new RelayCommand(obj => CloseWindow());
        }
    }
}
