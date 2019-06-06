using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentPayResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}