using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karigari.Integrations.Storage.User
{
    public class UserProvider : IUserProvider
    {
        public bool AddUser(Users user)
        {
            return true;
        }

        public bool DisableUser(int userId)
        {
            return true;
        }

        public IList<Users> GetAllUser()
        {
            IList<Users> users = new List<Users>();
            users.Add(new Users()
            {
                Address = new Address()
                {
                    City = "Pune",
                    Country = "India",
                    State = "Maharashtra",
                    Taluka = "Dhanori",
                    Village = "Dhanori Gaon",
                    Zip = "222132"
                },
                FirstName = "Amit ",
                LastName = "Malviya",
                Id = 23,
                AlternetContact = "352424252363",
                Contact = "32645237452374",
                Enabled = false,
                Gender = "Female"
            });
            users.Add(new Users()
            {
                Address = new Address()
                {
                    City = "Pune",
                    Country = "India",
                    State = "Maharashtra",
                    Taluka = "Dhanori",
                    Village = "Dhanori Gaon",
                    Zip = "222132"
                },
                FirstName = "Mahadev ",
                LastName = "sharma",
                Id = 23,
                AlternetContact = "352424252363",
                Contact = "32645237452374",
                Enabled = false,
                Gender = "Female"
            });
            return users;
        }

        public Users GetUserById(int userId)
        {
            Users user = new Users()
            {

                Address = new Address()
                {
                    City = "Pune",
                    Country = "India",
                    State = "Maharashtra",
                    Taluka = "Dhanori",
                    Village = "Dhanori Gaon",
                    Zip = "222132"
                },
                FirstName = "Mahadev ",
                LastName = "sharma",
                Id = 23,
                AlternetContact = "352424252363",
                Contact = "32645237452374",
                Enabled = false,
                Gender = "Female"
            };
            return user;
        }


        public Users GetUserByName(string name)
        {
            Users user = new Users()
            {

                Address = new Address()
                {
                    City = "Pune",
                    Country = "India",
                    State = "Maharashtra",
                    Taluka = "Dhanori",
                    Village = "Dhanori Gaon",
                    Zip = "222132"
                },
                FirstName = "Mahadev ",
                LastName = "sharma",
                Id = 23,
                AlternetContact = "352424252363",
                Contact = "32645237452374",
                Enabled = false,
                Gender = "Female"
            };
            return user;
        }

        public bool UpdateUser(Users user, int id)
        {
            return true;
        }
    }
}
