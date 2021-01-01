using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HBNYAPI.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string ShortContent { get; set; }
        public string NewsContent { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
