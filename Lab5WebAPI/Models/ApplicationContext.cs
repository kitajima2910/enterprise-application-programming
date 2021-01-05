using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5WebAPI.Models
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base(dbContext)
        {
                
        }

        public DbSet<Employee> GetEmployees { get; set; }
    }
}
