using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAP2WEBAPP.Models
{
    [Table("tbNews")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string NewsId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string NewsContent { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfPublish { get; set; }
    }
}
