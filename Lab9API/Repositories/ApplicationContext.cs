using Lab9DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab9API.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> GetCountries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Lab9DB;Integrated Security=True;Pooling=False");
        }
    }
}
