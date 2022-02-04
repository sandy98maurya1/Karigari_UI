using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karigari.Integrations.Storage.User
{
    public class UserProvider : IUserProvider
    {
        IConfiguration _configuration;
        internal string apiUrl { get; set; }
        public UserProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            apiUrl = GetApiUrl();
        }
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
        public string GetApiUrl()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }

        public IList<StateDetails> GetStateDetails(int countryId)
        {
            List<StateDetails> stateDetails = new List<StateDetails>()
            {
                new StateDetails() { StateId= 1, Name = "India"},
                new StateDetails() { StateId= 2, Name = "Pakistan"},
                new StateDetails() { StateId= 3, Name = "Australia"},
                new StateDetails() { StateId= 4, Name = "South Africa"}
            };
            return stateDetails;
        }

        public IList<DivisionDetails> GetDivisionDetails(int stateId)
        {
            List<DivisionDetails> division = new List<DivisionDetails>()
            {
                new DivisionDetails() {  DivisionId = 11, Name = "India DivisionId"},
                new DivisionDetails() { DivisionId = 12, Name = "Pakistan DivisionId"},
                new DivisionDetails() { DivisionId = 13, Name = "Australia DivisionId"},
                new DivisionDetails() { DivisionId =14, Name = "South Africa DivisionId"}
            };
            return division;
        }

        public IList<TalukaDetails> GetTalukaDetails(int divisionId)
        {
            List<TalukaDetails> taluka = new List<TalukaDetails>()
            {
                new TalukaDetails() { TalukaId = 21, Name = "India TalukaId"},
                new TalukaDetails() { TalukaId = 22, Name = "Pakistan TalukaId"},
                new TalukaDetails() { TalukaId = 23, Name = "Australia TalukaId"},
                new TalukaDetails() { TalukaId = 24, Name = "South Africa TalukaId"}
            };
            return taluka;
        }
    }
}
