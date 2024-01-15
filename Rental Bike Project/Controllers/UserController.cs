using Microsoft.AspNetCore.Mvc;
using Rental_Bike_Project.Models;

namespace Rental_Bike_Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            var name = HttpContext.Session.GetString("Username");
            return View(name);
        }

        public IActionResult SignUp(SignUpModel user)
        {
              
            return Json(new { success = true, message = "Signup successful." });
           
        }

        public IActionResult Login(LoginModel userdetails)
        {
            HttpContext.Session.SetString("Username", userdetails.Username);
            return Json(new { success = true, message = "Login successful." });

        }

        public IActionResult Logout()
        {
            // Clear session data
            HttpContext.Session.Clear();

            return RedirectToAction("Home", "User");
        }
    }
}
