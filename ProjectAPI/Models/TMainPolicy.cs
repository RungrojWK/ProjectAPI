using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectAPI.Models
{
    public partial class TMainPolicy
    {
        public short CompanyCode { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public string OicplanCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string GroupInsurance { get; set; }

    }
}
