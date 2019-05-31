using Payment.Manager;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Utility
{
    public class SendSMS
    {
       public static bool SendSms(string phonenumber, int smscode)
        {
            if (phonenumber.Substring(0, 4) == "+374" && phonenumber.Length==11)
            {
                return true;
            }
            return false;
        }
    }
}