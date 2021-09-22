using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectAPI.Models
{
    public partial class AuthorDto
    {
        public AuthorDto()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
