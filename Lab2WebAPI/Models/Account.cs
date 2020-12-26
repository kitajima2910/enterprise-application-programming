using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2WebAPI.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string PinCode { get; set; }
        public double Balance { get; set; }
    }
}
