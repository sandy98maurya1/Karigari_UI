using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karigari.Integrations.Domains.User
{
    public interface IUserDomain
    {
        bool AddUser(Users user);
        bool UpdateUser(Users user, int id);
        bool DisableUser(int userId);
        IList<Users> GetAllUser();
        Users GetUserById(int userId);
        Users GetUserByName(string name);
        IList<StateDetails> GetStateDetails(int countryId);
        IList<DivisionDetails> GetDivisionDetails(int stateId);
        IList<TalukaDetails> GetTalukaDetails(int divisionId);
    }
}
