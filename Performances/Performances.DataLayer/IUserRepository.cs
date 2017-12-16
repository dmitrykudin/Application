﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performances.Model;

namespace Perfomances.DataLayer
{
    public interface IUserRepository
    {
        User CreateUser(User user, File photo);
        User GetUserById(Guid userId);
        List<User> GetAllUsers();
        void DeleteUser(User user);
        void DeleteUser(Guid userId);
        User UpdateUser(User user, User newUser);
    }
}
