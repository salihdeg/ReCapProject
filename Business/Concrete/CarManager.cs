using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarCheckService _carCheckService;

        public CarManager(ICarDal carDal,ICarCheckService carCheckService)
        {
            _carDal = carDal;
            _carCheckService = carCheckService;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId==id);
        }
        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p=>p.DailyPrice>=min && p.DailyPrice<=max);
        }

        public void Add(Car car)
        {
            if (_carCheckService.CheckCarRules(car))
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("Araç Kurallara Uymuyor!");
            }
        }

        public void Update(Car car)
        {
            if (_carCheckService.CheckCarRules(car))
            {
                _carDal.Update(car);
            }
            else
            {
                throw new Exception("Araç Kurallara Uymuyor!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
    }
}
