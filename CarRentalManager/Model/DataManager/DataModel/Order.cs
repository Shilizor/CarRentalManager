using System;
using System.Runtime;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Model.DataManager.DataModel
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DataTime { get; set; }
        public string status { get; set; } = "Ожидает оплаты";
        public int UserID { get; set; }
        public int CarID { get; set; }
        public int CountDay { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
