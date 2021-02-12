using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CheckRules());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal(), new EfCarDal());

            //Hata verecek olan Araba
            //carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 0, CarDescription = "e" });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 540000, CarDescription = "2018 Mercedes-AMG® GT C Coupe White" });

            //ListAllBrands(brandManager);

            //ListAllColors(colorManager);

            //ListAllCarDetails(carManager);
            //AddTwoUser(userManager);
            //ListAllUsers(userManager);
            //AddTwoCustomer(customerManager);
            //ListAllCustomers(customerManager);

            //Rental rental1 = new Rental { CustomerId=1,RentDate=DateTime.Now, CarId = 1};
            //rentalManager.Add(rental1,carManager.GetById(rental1.CarId).Data);

            //GetAllRentalDetails(rentalManager);

        }

        private static void GetAllRentalDetails(RentalManager rentalManager)
        {
            Console.WriteLine();
            foreach (var rental in rentalManager.GetRentalDetail().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} ", rental.CarDescription, rental.CompanyName, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void ListAllCustomers(CustomerManager customerManager)
        {
            Console.WriteLine("Customers:");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void AddTwoCustomer(CustomerManager customerManager)
        {
            customerManager.Add(new Customer
            {
                CompanyName = "SaDeSoft",
                UserId = 1
            });
            customerManager.Add(new Customer
            {
                CompanyName = "KodlamaIo",
                UserId = 2
            });
        }

        private static void ListAllUsers(UserManager userManager)
        {
            Console.WriteLine("Kullanıcılar: ");
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }
        }

        private static void AddTwoUser(UserManager userManager)
        {
            userManager.Add(new User
            {
                FirstName = "Salih",
                LastName = "Değirmenci",
                Email = "salihdegirmenci99@gmail.com",
                UserPassword = "sd123456"
            });
            userManager.Add(new User
            {
                FirstName = "Engin",
                LastName = "Demiroğ",
                Email = "engindemirog@gmail.com",
                UserPassword = "ed123456"
            });
        }

        private static void ListAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("\t\tCar Details:");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", car.BrandName, car.CarDescription, car.ColorName, car.DailyPrice);
            }
        }

        private static void ListAllColors(ColorManager colorManager)
        {
            Console.WriteLine("\t\tColors:");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ListAllBrands(BrandManager brandManager)
        {
            Console.WriteLine("\t\tBrands:");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
