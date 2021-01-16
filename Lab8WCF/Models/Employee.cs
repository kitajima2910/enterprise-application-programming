using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab8WCF.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string Photo { get; set; }
    }
}