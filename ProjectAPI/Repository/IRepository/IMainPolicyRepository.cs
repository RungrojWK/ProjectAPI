using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;

namespace ProjectAPI.Repository.IRepository
{
    public interface IMainPolicyRepository
    {
        ICollection<TMainPolicy> GetPolicy();
        bool Save();
    }
}
