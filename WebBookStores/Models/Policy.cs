using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OICIBLSWEB.Models
{
    public class Policy
    {
        public short CompanyCode { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public string OicplanCode { get; set; }
        public string GroupInsurance { get; set; }
    }
}
