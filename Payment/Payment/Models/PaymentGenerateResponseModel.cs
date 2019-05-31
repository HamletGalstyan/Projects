using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentGenerateResponseModel
    {
        public bool IsSuccess { get; set; }
        public int PaymentId { get; set; }
        public string Message { get; set; }
    }
}