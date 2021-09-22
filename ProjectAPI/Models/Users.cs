using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectAPI.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreateDate { get; set; }
        public string CreateBy { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
