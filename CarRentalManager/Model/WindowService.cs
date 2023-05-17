using CarRentalManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalManager.Model
{
    public class WindowService : IWindowService
    {
        public void CloseWindow()
        {
            // Get a reference to the current window
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            // Close the window
            if (window != null)
            {
                window.Close();
            }
        }

        public void ShowRegWindow()
        {
            var window = new MainReg();
            window.Show();
        }
    }
}
