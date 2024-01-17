using Microsoft.AspNetCore.Mvc;
using Rental_Bike_Project.Models;

namespace Rental_Bike_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            var username = Request.Cookies["Username"];
            ViewBag.Username = username;    
            return View();
        }

        public IActionResult SignUp(SignUpModel user)
        {
            _context.RegisterUers.Add(user);
            _context.SaveChanges(); 
              
            return Json(new { success = true, message = "Signup successful." });
          
           
        }

        public IActionResult Login(LoginModel userdetails)
        {
            //HttpContext.Session.SetString("Username", userdetails.Username); 
            //HttpContext.Session.SetString("SessionKeyName", "The Doctor");
            //HttpContext.Session.SetInt32("SessionKeyAge", 73);
           
            var user = _context.RegisterUers.FirstOrDefault(u => u.Email == userdetails.Email);

            if (user!=null)
            {
                if(user.Password == userdetails.Password)
                {
                    var username = user.Username;
                    CookieOptions option = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30)
                    };

                    Response.Cookies.Append("UserName", username, option);

                    return Json(new { success = true, message = "Login successful." });
                }
                else
                {
                    return Json(new { success = false, message = "Login Unsuccessful." });
                }

            }
            else
            {
                return Json(new { success = false, message = "Login Unsuccessful." });
            }


            

         //   return View();  

        }

        public IActionResult Logout()
        {
            // Clear cookies data
            Response.Cookies.Delete("UserName");

            return RedirectToAction("Home", "User");
        }

        public IActionResult Bikes(int id)
        {
            if (id == 0)
            {
                var categories = _context.Bike_Categories.ToList();
                var bikes = _context.Bike_Details.ToList();

                var viewModel = new BikeViewModel
                {
                    Categories = categories,
                    Bikes = bikes
                };
                return View(viewModel);
            }
            else
            {
                var categories = _context.Bike_Categories.ToList();
                var details = _context.Bike_Details
                             .Where(detail => detail.Cid == id)
                             .ToList();

                var viewModel = new BikeViewModel
                {
                    Categories = categories,
                    Bikes = details
                };
                return View(viewModel);
            }
            
        }

        


    }
}
