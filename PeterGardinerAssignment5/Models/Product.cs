using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^d{3}-\d{10}$", ErrorMessage = "Enter a valid number bruh")]
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        //new pages added
        public int pages { get; set; }
    }
}
