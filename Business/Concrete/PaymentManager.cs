using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IRentalService _rentalService;
        public PaymentManager(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [TransactionScopeAspect]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult GetPayment(PaymentInfo paymentInfo, Rental rental)
        {
            var rentResult = _rentalService.Add(rental);
            if (rentResult.Success)
            {
                return new SuccessResult(Messages.PaymentSuccess);
            }
            return rentResult;
        }
    }
}
