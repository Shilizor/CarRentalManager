using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Model
{
    public interface IWindowService
    {
        void ShowRegWindow();
        void ShowAuthWindow();
        void ShowMainWindow();
        void CloseWindow();
    }
}
