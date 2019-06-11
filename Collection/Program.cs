using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection collection = new Collection();

            collection[0] = new Elements(0);
            collection[1] = new Elements(1);
            collection[2] = new Elements(2);
            collection[3] = new Elements(3);

            foreach (Elements item in collection)
            {
                Console.WriteLine("{0}",item.Field_A);
            }
        }
    }
}
