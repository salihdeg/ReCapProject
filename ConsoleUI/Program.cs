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
            CarManager carManager = new CarManager(new EfCarDal(),new CheckRules());

            //Hata verecek olan Araba
            //carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 0, CarDescription = "e" });

            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 540000, CarDescription = "2018 Mercedes-AMG® GT C Coupe White" });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = Convert.ToDateTime("01.01.2018"), DailyPrice = 540000, CarDescription = "2018 Mercedes-AMG® GT C Coupe White" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear.Month);
            }

        }
    }
}
