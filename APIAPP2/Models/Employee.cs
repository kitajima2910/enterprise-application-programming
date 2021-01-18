using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIAPP2.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\w{2,}@\w{2,}(\.\w{2,}){1,2}$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
    }
}
