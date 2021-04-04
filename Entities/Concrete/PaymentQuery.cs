using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentQuery : IEntity
    {
        public PaymentInfo paymentInfo { get; set; }
        public Rental rental { get; set; }
    }
}
