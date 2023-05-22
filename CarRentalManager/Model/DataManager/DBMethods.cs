using CarRentalManager.Model.DataManager.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Model.DataManager
{
    public static class DBMethods 
    {
        public static bool IsCorrectLoginPassword(string login, string password)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                return user != null ? false : true;
            }
        }
        public static bool IsCorrectLoginEmail(string login, string email)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login || u.Email == email);

                return user != null ? false : true;
            }
        }

        #region Getting data from database

        // Получение данных о всех автомобилей

        public static List<Car> GetAllCars()
        {
            using (var context = new ApplicationContext())
            {
                return context.Cars.ToList();
            }
        }

        // Получение всех пользователей

        public static List<User> GetAllUsers()
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.ToList();
            }
        }

        // Получение данных пользователя по логину аккаунта
        public static User GetUser(string login)
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == login);
            }
        }

        // Получение данных пользователя по индификацирнному номеру аккаунта
        public static User GetUser(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        // Получение всех типов автомобилей

        public static List<TypeCar> GetAllTypeCar()
        {
            using (var context = new ApplicationContext())
            {
                return context.TypeCars.ToList();
            }
        }

        // Получение всех заказов

        public static List<Order> GetAllOrder()
        {
            using (var context = new ApplicationContext())
            {
                return context.Orders.ToList();
            }
        }

        // Получение всех банковских счетов пользователей

        public static List<Bank> GetAllBanks()
        {
            using (var context = new ApplicationContext())
            {
                return context.Banks.ToList();
            }
        }

        #endregion


        #region Sending data from database

        // Добавление данных об автомобиле

        public static void AddCar(Car car)
        {
            using (var context = new ApplicationContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        // Добавление пользователя

        public static void AddUser(User user)
        {
            using (var context = new ApplicationContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // Добавление типа автомобиля


        public static void AddTypeCar(TypeCar typecar)
        {
            using (var context = new ApplicationContext())
            {
                context.TypeCars.Add(typecar);
                context.SaveChanges();
            }
        }

        // Добавление заказа
        public static void AddOrder(Order order)
        {
            using (var context = new ApplicationContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        // Добавление банковского счета
        public static void AddBankUser(int UserID)
        {
            using (var context = new ApplicationContext())
            {
                var bank = new Bank { UserID = UserID, Sum = 0 };
                context.Banks.Add(bank);
                context.SaveChanges();
            }
        }

        // Изменение данных об автомобиле

        // Изменение данных об пользователя

        // Изменение типа автомобиля

        // Изменение заказа

        #endregion
    }
}
