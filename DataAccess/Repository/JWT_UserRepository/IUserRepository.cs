using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.JWT_UserRepository
{
    public interface IUserRepository
    {
        UserDTO GetUser(UserModel userMode);
    }

}
