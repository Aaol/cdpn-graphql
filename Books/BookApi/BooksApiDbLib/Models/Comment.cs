using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApiDbLib.Models
{
    /// <summary>
    ///     Classe représentant un commentaire de livre
    /// </summary>
    public class BookComment
    {
        [Required]
        public string Comment { get; set; }
        [Required]        
        public Book Book { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public long Identifier { get; set; }

    }
}