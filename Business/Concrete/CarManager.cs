﻿using Business.Abstract;
using Business.BusinessAspectts.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using static Core.Aspects.Autofac.Caching.CacheAspect;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAvailableCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.IsAvailable == true));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImagesById(int carId)
        {
            var result = _carDal.GetCarImagesById(carId);

            if (result.Count == 0)
            {
                var errorResult = IfCarHasNoImages(carId);
                return new ErrorDataResult<List<CarImageDetailDto>>(errorResult);
            }
            return new SuccessDataResult<List<CarImageDetailDto>>(result);
        }
        #region BusinessRules
        private List<CarImageDetailDto> IfCarHasNoImages(int carId)
        {
            Car car = _carDal.Get(c => c.Id == carId);
            List<CarImageDetailDto> errorResult = new List<CarImageDetailDto>() { new CarImageDetailDto { CarId = car.Id, CarDescription = car.CarDescription, ImageDate = DateTime.Now, ImagePath = ImageInfo.DefaultImage } };
            return errorResult;
        }
        #endregion
    }
}
