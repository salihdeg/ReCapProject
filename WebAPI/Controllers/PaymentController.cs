using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("getpayment")]
        public IActionResult GetPayment(PaymentQuery paymentQuery)
        {
            PaymentInfo paymentInfo = paymentQuery.paymentInfo;
            Rental rental = paymentQuery.rental;
            var result = _paymentService.GetPayment(paymentInfo, rental);
            return Ok(result);
        }
    }
}
