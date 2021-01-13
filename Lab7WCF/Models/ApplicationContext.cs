using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7WCF.Models
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Lab7DB;Integrated Security=True;Pooling=False");
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Staff> Staffs{ get; set; }
    }
}