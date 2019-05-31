using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentPayRequestModel
    {
        [Required]
        public int PaymentId { get; set; }
    }
}