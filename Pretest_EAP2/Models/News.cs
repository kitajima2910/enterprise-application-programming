using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAP2.Models
{
    [Table("tbNews")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NewsId { get; set; }
        public string NewsContent { get; set; }
        public DateTime DateOfPublish { get; set; }
    }
}
