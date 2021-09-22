using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.Data;
using ProjectAPI.Models;

namespace ProjectAPI.Repository.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly OIC_IBLS_DEMO_1Context _db;
        private readonly AppSettings _appSettings;
        public UserRepository(OIC_IBLS_DEMO_1Context db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        public Users Authenticate(string username, string password)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }


        public bool isUniqeUser(string username)
        {
            throw new NotImplementedException();
        }

        public Users Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
