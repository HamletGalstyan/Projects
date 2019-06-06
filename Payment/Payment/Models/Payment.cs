using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
  
    public class Payments
    {
        Random random = new Random();

        public string Acc;
        public string MobilePhone="+37443******";
        public int Amount;
        public int State;
        public int SmsCode;
        public string Description;
        public DateTime CreationTime;
        public DateTime LastModifiedTime;
        public DateTime? AppproveData=null;
        public Payments()
        {

        }
        public Payments(string acc, int amount,  string description)
        {
            Acc = acc;
            Amount = amount;
            State = 1;
            SmsCode = random.Next(1000, 9999);
            Description = description;
            CreationTime = DateTime.Now;
            LastModifiedTime = DateTime.Now;
            
        }

    }
}