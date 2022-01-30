using Karigari.Integrations.Domains.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

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

            return View(_userDomain.GetUserById(id));
        }

        [HttpGet]
        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                GetFormData(collection);
               // _userDomain.AddUser(user);
                return RedirectToAction(nameof(Index));
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



        private Users GetFormData(IFormCollection collection)
        {
            throw new NotImplementedException();
        }


    }
}
