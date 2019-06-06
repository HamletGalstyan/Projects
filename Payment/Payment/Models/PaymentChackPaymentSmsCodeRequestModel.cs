using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentChackPaymentSmsCodeRequestModel
    {
        [Required]
        public int SmsCode { get; set; }
        [Required]
        public int PaymentId { get; set; }
    }
}