using System;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1)Add");
                Console.WriteLine("2)Delete");
                Console.WriteLine("3)Update");
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.Key == ConsoleKey.D1)
                {
                    DAL.Add();
                }
                else if (info.Key == ConsoleKey.D2)
                {
                    DAL.Remove();
                }
                else if (info.Key == ConsoleKey.D3)
                {
                    DAL.Update();
                }
            }
        }
    }
}
