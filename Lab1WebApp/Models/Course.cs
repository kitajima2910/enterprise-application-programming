using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebApp.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public decimal Fee { get; set; }
    }
}
