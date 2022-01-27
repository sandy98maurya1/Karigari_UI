using Microsoft.AspNetCore.Mvc;
using Models;

namespace KarigariUI.Controllers
{
    public class LabourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Address user)
        {
            try
            {
                // _userDomain.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }
    }
}
