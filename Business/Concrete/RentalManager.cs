using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }
        [TransactionScopeAspect]
        public IResult Add(Rental entity)
        {
            Car car = _carDal.Get(c => c.Id == entity.CarId);

            if (car.IsAvailable == false)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            _rentalDal.Add(entity);
            car.IsAvailable = false;
            _carDal.Update(car);
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult Delete(Rental entity)
        {
            try
            {
                _rentalDal.Delete(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DefaultError);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rental>>(Messages.DefaultError);
            }
        }

        public IDataResult<Rental> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Rental>(Messages.DefaultError);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<RentalDetailDto>>(Messages.DefaultError);
            }
        }
        [TransactionScopeAspect]
        public IResult Update(Rental entity)
        {
            try
            {
                _rentalDal.Update(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DefaultError);
            }
        }
    }
}
