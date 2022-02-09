using Karigari.Integrations.Domains.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enum;
using System;
using System.Globalization;

namespace KarigariUI.Controllers
{
    public class UserController : Controller
    {
        IUserDomain _userDomain;
        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }
        // GET: UserController
        public ActionResult Index()
        {
            _userDomain.GetAllUser();
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var ss = _userDomain.GetAllUser();
            return View(_userDomain.GetUserById(id));
        }

        [HttpGet]
        // GET: UserController/Create
        public ActionResult Create()
        {
            Users user = new Users()
            {
                Address = new Address()
                {
                    Country = new System.Collections.Generic.List<CountryDetails>() { new CountryDetails() { CountryId = 1, Name = "India" } },
                    State = new System.Collections.Generic.List<StateDetails>(),
                    City = new System.Collections.Generic.List<DivisionDetails>(),
                    Taluka = new System.Collections.Generic.List<TalukaDetails>()
                }
            };
            return View(user);
        }

        // POST: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                UsersRequestInput usersRequestInput = GetFormData(collection);
                _userDomain.AddUser(usersRequestInput);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }
        // GET: UserController/Edit/5 
        public ActionResult Edit(int id)
        {
            return View(_userDomain.GetUserById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                _userDomain.UpdateUser(user, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        private UsersRequestInput GetFormData(IFormCollection collection)
        {
            CultureInfo culture = new CultureInfo("en-US");
            var users = new UsersRequestInput()
            {
                FirstName = collection["FirstName"].ToString(),
                LastName = collection["LastName"].ToString(),
                Contact = collection["Contact"].ToString(),
                Gender = collection["Gender"].ToString(),
                DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"].ToString(), culture),
                WorkerType = collection["WorkerType"].ToString(),
                Password = collection["Password"].ToString(),
                Address = new AddressRequest()
                {
                    Country = Convert.ToInt32(collection["Address.Country"]),
                    State = Convert.ToInt32(collection["Address.State"]),
                    City = Convert.ToInt32(collection["Address.City"]),
                    Taluka = Convert.ToInt32(collection["Address.Taluka"]),
                    Village = collection["Address.Village"].ToString(),
                    Zip = collection["Address.Zip"].ToString()
                }
            };
            return users;
        }






        [HttpPost]
        public JsonResult GetStateDetails(int countryId)
        {
            var state = _userDomain.GetStateDetails(2);
            return Json(new { data = state });
        }
        [HttpPost]
        public JsonResult GetDivisionDetails(int stateId)
        {
            var division = _userDomain.GetDivisionDetails(stateId);
            return Json(new { data = division });
        }
        [HttpPost]
        public JsonResult GetTalukaDetails(int divisionId)
        {
            var taluka = _userDomain.GetTalukaDetails(divisionId);
            return Json(new { data = taluka });

        }
    }
}
