using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApiDbLib.Models
{
    /// <summary>
    ///     Classe représentant un livre
    /// </summary>
    public class Book
    {
        [Required]
        public string Title { get; set; }
        public string Type { get; set; }
        [Required]        
        public Author Author { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]        
        public float Price { get; set; }
        [Required]
        public long Identifier { get; set; }

    }
}