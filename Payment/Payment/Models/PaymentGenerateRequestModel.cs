using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentGenerateRequestModel
    {
        
        [Required]
        [StringLength(16)]
        public string Acc { get; set; }
        [Required]
        [Range(1000,100000)]
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}