using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performances.Model;

namespace Perfomances.DataLayer
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int userId);
        void DeleteUser(User user);
        void DeleteUser(int userId);
        User UpdateUser(User user, User newUser);
    }
}
