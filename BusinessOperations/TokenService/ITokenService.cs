using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOperations.TokenService
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string audience, string token);
    }

}
