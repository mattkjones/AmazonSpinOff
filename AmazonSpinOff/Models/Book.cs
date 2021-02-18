using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSpinOff.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Author's First Name")]
        public string AuthorFirst { get; set; }
        [Required(ErrorMessage = "Please enter Author's Last Name")]
        public string AuthorLast { get; set; }
        [Required(ErrorMessage = "Please enter the Publisher")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Please enter valid IBSN")]
        [RegularExpression(@"^(?= (?:\D *\d{10} (?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "IBSN not valid, please enter valid IBSN")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Please enter a Classification")]
        public string Classification { get; set; }
        [Required(ErrorMessage = "Please enter a Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }
    }
}
