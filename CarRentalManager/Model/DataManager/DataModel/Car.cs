using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Model.DataManager.DataModel
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string ReleaseData { get; set; }
        public int TypeCarID { get; set; }

        public decimal CostCar { get; set; }
        public string StateNumber { get; set; }
    }
}
