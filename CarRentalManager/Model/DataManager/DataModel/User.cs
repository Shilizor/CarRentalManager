
using System.Windows.Documents;

namespace CarRentalManager.Model.DataManager.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Status { get; set; } = "Пользователь";
        public decimal Money { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
