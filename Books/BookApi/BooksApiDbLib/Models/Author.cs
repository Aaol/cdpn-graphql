using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApiDbLib.Models
{
    public class Author : IHaveIdentifier
    {
        [Required]        
        public string FirstName { get; set; }
        [Required]        
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; } 
        public List<Book> Books { get; set; }
        [Required]
        public long Identifier { get; set; }
    }
}