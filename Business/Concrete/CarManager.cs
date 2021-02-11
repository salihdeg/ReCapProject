using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==id));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max));
        }

        public IResult Add(Car car)
        {
            if (!_carCheckService.CheckCarRules(car))
            {
                return new ErrorResult(Messages.EntityInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Update(Car car)
        {
            if (!_carCheckService.CheckCarRules(car))
            {
                return new ErrorResult(Messages.EntityInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }
    }
}
