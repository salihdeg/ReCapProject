using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentQuery : IEntity
    {
        public PaymentInfo PaymentInfo { get; set; }
        public Rental Rental { get; set; }
    }
}
