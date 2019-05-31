using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Payment.Utility
{
    public class PAY
    {
       public static Random random = new Random();
        private static System.Timers.Timer aTimer;

        public static bool Credit(string Acc,int Amount)
        {
            SetTimer();
            if(Acc.Length==16 && Amount>1000 && Amount<100000)
            {
                return true;
            }
            return false;
        }

        public static void SetTimer()
        {
            int t = random.Next(300, 3000);
            aTimer = new System.Timers.Timer(t);
        }
    }
}