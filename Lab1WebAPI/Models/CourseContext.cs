using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebAPI.Models
{
    public class CourseContext
    {
        public static List<Course> courses = new List<Course>()
        {
            new Course{ CourseId = "SQL Server", Description = "Database Design and programing", Duration = "1 months", Fee = 2005000 },
            new Course{ CourseId = "Web service", Description = "Programing with Microsoft Azuze", Duration = "2 month", Fee = 3200000 }
        };
    }
}
