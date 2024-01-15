using Microsoft.AspNetCore.Mvc;
using Rental_Bike_Project.Models;

namespace Rental_Bike_Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            var username = Request.Cookies["Username"];
            ViewBag.Username = username;    
            return View();
        }

        public IActionResult SignUp(SignUpModel user)
        {
              
            return Json(new { success = true, message = "Signup successful." });
           
        }

        public IActionResult Login(LoginModel userdetails)
        {
            //HttpContext.Session.SetString("Username", userdetails.Username);
            //HttpContext.Session.SetString("SessionKeyName", "The Doctor");
            //HttpContext.Session.SetInt32("SessionKeyAge", 73);

            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("UserName", userdetails.Username, option);

            return Json(new { success = true, message = "Login successful." });

        }

        public IActionResult Logout()
        {
            // Clear cookies data
            Response.Cookies.Delete("UserName");

            return RedirectToAction("Home", "User");
        }

        public IActionResult Bikes()
        {
            return View();  
        }
    }
}
