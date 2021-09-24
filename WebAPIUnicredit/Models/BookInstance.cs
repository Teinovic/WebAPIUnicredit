using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUnicredit.Models
{
    public class BookInstance
    {
        [Key]
        public int id { get; set; }
        
        [Column(TypeName ="nvarchar(100)")]
        public string bookName { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string authorName { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        public string shortDescription { get; set; }
        
        public int yearPublished { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string genre { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string publisher { get; set; }
    }
}
