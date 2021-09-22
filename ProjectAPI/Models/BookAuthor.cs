using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectAPI.Models
{
    public partial class BookAuthor
    {
        [Key]
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public byte? AuthorOrder { get; set; }
        public int? RoyalityPercentage { get; set; }

        public virtual AuthorDto Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
