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

            //Hata verecek olan Araba
            //carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 0, CarDescription = "e" });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 540000, CarDescription = "2018 Mercedes-AMG® GT C Coupe White" });

            //Marka Ekleme
            //brandManager.Add(new Brand
            //{
            //    BrandName = "Subaru"
            //});

            Console.WriteLine("\t\tBrands:");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("\t\tColors:");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\t\tCar Details:");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2} {3}", car.BrandName, car.CarDescription, car.ColorName, car.DailyPrice);
            }

        }
    }
}
