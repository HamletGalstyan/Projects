using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentChackPaymentSmsCodeResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}