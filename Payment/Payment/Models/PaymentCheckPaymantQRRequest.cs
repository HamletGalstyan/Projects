using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentCheckPaymantQRRequest
    {
        [Required]
        [Range(0,int.MaxValue)]
        public int PaymentId { get; set; }
    }
}