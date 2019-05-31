using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notebook
{
    class DAL
    {
        public static void Add()
        {
            Console.Clear();
            Console.WriteLine("Write Name");
            string name = Console.ReadLine();
            Console.WriteLine("Write Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Write Address");
            string address = Console.ReadLine();
            Console.WriteLine("Write Phone");
            string phone = Console.ReadLine();

            using (MyContext my = new MyContext())
            {
                User user = new User { Name = name, Surname = surname, Address = address, Phone = phone };

                my.Users.Add(user);
                my.SaveChanges();
                var users = my.Users.ToList();
                Console.WriteLine("Data is Added");
                Console.WriteLine("The data list");
                foreach (User item in users)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Surname},{item.Address},{item.Phone}");
                }
                Console.Read();
            }

        }
       
        public static void Remove()
        {
            Console.Clear();
            Console.WriteLine("Write data's Id");
            int id = Convert.ToInt32(Console.ReadLine());
            User user = new User { Id = id };

            using (MyContext my = new MyContext())
            {
                User deleteUser = my.Users.Where(u => u.Id == id).SingleOrDefault();

                if(deleteUser != null)
                {
                    my.Users.Remove(deleteUser);
                    my.SaveChanges();
                }

                Console.WriteLine("Data is deleted");
            }
        }

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Write Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Write Name");
            string name = Console.ReadLine();
            Console.WriteLine("Write Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Write Address");
            string address = Console.ReadLine();
            Console.WriteLine("Write Phone");
            string phone = Console.ReadLine();
 
            using (MyContext my = new MyContext())
            {
                User user = my.Users.Where(item => item.Id == id).SingleOrDefault();
                if (user != null)
                {
                    user.Name = name;
                    user.Surname = surname;
                    user.Address = address;

                    my.Users.Update(user);
                    my.SaveChanges();
                    Console.WriteLine("Data is ubdated");
                }
                else
                {
                    Console.WriteLine("Data is not exist");
                }
            }
                 

           
        }

    }
}
