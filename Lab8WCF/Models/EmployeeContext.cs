using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8WCF.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> GetEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Lab8DB;Integrated Security=True;Pooling=False");
        }
    }
}