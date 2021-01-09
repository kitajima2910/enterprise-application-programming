using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAPWepAPI.Models
{
    public class ApplicationContext : DbContext
    {


        public DbSet<Employee> GetEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True;Pooling=False");
        }
    }
}
