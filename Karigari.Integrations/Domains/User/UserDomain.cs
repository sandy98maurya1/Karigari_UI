using Karigari.Integrations.Storage.User;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karigari.Integrations.Domains.User
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserProvider _provider;
        public UserDomain(IUserProvider provider)
        {
            _provider = provider;
        }


        public bool AddUser(Users user)
        {
         return   _provider.AddUser(user);
        }

        public bool DisableUser(int userId)
        {
           return _provider.DisableUser(userId);
        }

        public IList<Users> GetAllUser()
        {
          return  _provider.GetAllUser();
        }

        public Users GetUserById(int userId)
        {
          return  _provider.GetUserById(userId);
        }

        public Users GetUserByName(string name)
        {
          return  _provider.GetUserByName(name);
        }

        public bool UpdateUser(Users user, int id)
        {
         return  _provider.UpdateUser(user, id); 
        }
    }
}
