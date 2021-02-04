using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=150000,ModelYear=Convert.ToDateTime("01.01.2018"),CarDescription="2018 Model Mercedes"},
            new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=200000,ModelYear=Convert.ToDateTime("01.01.2019"),CarDescription="2019 Model Mercedes"},
            new Car{Id=3,BrandId=2,ColorId=1,DailyPrice=45000,ModelYear=Convert.ToDateTime("01.01.2014"),CarDescription="2014 Model Hyundai"},
            new Car{Id=4,BrandId=3,ColorId=1,DailyPrice=35000,ModelYear=Convert.ToDateTime("01.01.2015"),CarDescription="2015 Model Honda"},
            new Car{Id=5,BrandId=4,ColorId=1,DailyPrice=55000,ModelYear=Convert.ToDateTime("01.01.2010"),CarDescription="2010 Model Fiat Doblo"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Added Successfully!");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Deleted Successfully!");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine("Updated!");
        }
    }
}
