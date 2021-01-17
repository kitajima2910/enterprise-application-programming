using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> GetMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=MovieDB;Integrated Security=True;Pooling=False");
        }
    }
}