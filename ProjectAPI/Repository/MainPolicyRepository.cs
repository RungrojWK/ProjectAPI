using Microsoft.AspNetCore.DataProtection;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repository.IRepository
{
    public class MainPolicyRepository : IMainPolicyRepository
    {
        private readonly OIC_IBLS_DEMO_1Context _db;
        private readonly IDataProtector _protect;
        public MainPolicyRepository(OIC_IBLS_DEMO_1Context db, IDataProtectionProvider provider)
        {
            _db = db;
            _protect = provider.CreateProtector("MyProtector");
        }
        public ICollection<TMainPolicy> GetPolicy()
        {
            var outPut = _db.TMainPolicy.Select(x => _protect.Protect(x.PolicyNumber.ToString())).ToList();
            return _db.TMainPolicy.OrderBy(a => a.CompanyCode).ToList();

            //.OrderBy(a => a.CompanyCode).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
