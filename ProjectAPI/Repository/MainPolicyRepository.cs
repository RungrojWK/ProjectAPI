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
        public MainPolicyRepository(OIC_IBLS_DEMO_1Context db)
        {
            _db = db;
        }
        public ICollection<TMainPolicy> GetPolicy()
        {
            return _db.TMainPolicy.OrderBy(a => a.CompanyCode).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
