using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;

namespace ProjectAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUniqeUser(string username);
        Users Authenticate(string username, string password);
        Users Register(string username, string password);
    }
}
