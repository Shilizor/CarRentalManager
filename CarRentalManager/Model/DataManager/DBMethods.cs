using CarRentalManager.Model.DataManager.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Model.DataManager
{
    public static class DBMethods
    {
        public static List<User> GetAllUsers()
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.ToList();
            }
        }
        public static void AddUser(User user)
        {
            using (var context = new ApplicationContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
