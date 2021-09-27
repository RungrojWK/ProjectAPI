using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Timestamp]
        public string? CreateDate { get; set; }
        public DateTime? CreateBy { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}
