using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer entity)
        {
            try
            {
                _customerDal.Add(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DefaultError);
            }
        }

        public IResult Delete(Customer entity)
        {
            try
            {
                _customerDal.Delete(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DefaultError);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Customer>>(Messages.DefaultError);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(customer=>customer.Id == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Customer>(Messages.DefaultError);
            }
        }

        public IResult Update(Customer entity)
        {
            try
            {
                _customerDal.Update(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DefaultError);
            }
        }
    }
}
