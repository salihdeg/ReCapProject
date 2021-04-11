using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentInfo : IEntity
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Cvc { get; set; }
    }
}
