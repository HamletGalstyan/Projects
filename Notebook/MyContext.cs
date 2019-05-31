using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    public class MyContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }

        public void ApplicationContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-6ATJAK2\SQLEXPRESS; Database = Notebook;Trusted_Connection=True");
        }
    }
}
