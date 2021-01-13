﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretest_EAP2WCF.Models
{
    public class NewsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=NewsDB;Integrated Security=True;Pooling=False");
        }

        public DbSet<News> GetNews { get; set; }
    }
}