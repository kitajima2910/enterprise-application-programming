using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6WCF.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> GetBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Lab6DB;Integrated Security=True;Pooling=False");
        }
    }
}