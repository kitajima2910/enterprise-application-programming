using Lab3WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3WebAPI.Repositories
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
