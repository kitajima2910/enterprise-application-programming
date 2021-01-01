using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HBNYAPP.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string NewsId { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public string ShortContent { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string NewsContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostedDate { get; set; }
    }
}
