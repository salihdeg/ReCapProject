using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<PaymentInfo>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.CardNumber).NotEmpty();
            RuleFor(p => p.CardType).NotEmpty();
            RuleFor(p => p.Cvc).NotEmpty();
            RuleFor(p => p.ExpiryDate).NotEmpty();
            RuleFor(p => p.Cvc).MaximumLength(3);
            RuleFor(p => p.CardNumber).MaximumLength(16);
        }
    }
}
