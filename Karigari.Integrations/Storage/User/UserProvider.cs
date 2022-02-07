using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<bool>>(HttpMethod.Post, "/AddUser", user);
            return usersDeatils.Data;
        }
        public bool DisableUser(int userId)
        {
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<bool>>(HttpMethod.Post, "/DeleteUser?userId=" + userId, null);
            return usersDeatils.Data;
        }
        public IList<Users> GetAllUser()
        {
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<List<Users>>>(HttpMethod.Get, "/GetUsers", null);
            return usersDeatils.Data;
        }
        public Users GetUserById(int userId)
        {
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<Users>>(HttpMethod.Get, "/GetUsersById?id=" + userId, null);
            return usersDeatils.Data;
        }
        public Users GetUserByName(string name)
        {
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<Users>>(HttpMethod.Get, "/GetUsersById?id=" + name, null);
            return usersDeatils.Data;
        }
        public bool UpdateUser(Users user, int id)
        {
            var usersDeatils = ConsumeApiService.ConsumeApi<ApiResponse<Users>>(HttpMethod.Post, "/GetUsersById?id=" + id, user);
            return true;
        }
        public IList<StateDetails> GetStateDetails(int countryId)
        {
            var states = ConsumeApiService.ConsumeApi<ApiResponse<IList<StateDetails>>>(HttpMethod.Get, "/GetStateDetails?countryId=" + countryId, null);
            return states.Data;
        }
        public IList<DivisionDetails> GetDivisionDetails(int stateId)
        {
            var states = ConsumeApiService.ConsumeApi<ApiResponse<IList<DivisionDetails>>>(HttpMethod.Get, "/GetDivisionDetails?stateId=" + stateId, null);

            return states.Data;
        }
        public IList<TalukaDetails> GetTalukaDetails(int divisionId)
        {
            var taluka = ConsumeApiService.ConsumeApi<ApiResponse<IList<TalukaDetails>>>(HttpMethod.Get, "/GetTalukaDetails?divisionId=" + divisionId, null);

            return taluka.Data;
        }
        public string GetApiUrl()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }
    }
}
