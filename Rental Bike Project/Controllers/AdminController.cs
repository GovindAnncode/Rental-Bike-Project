using Microsoft.AspNetCore.Mvc;
using Rental_Bike_Project.Models;

namespace Rental_Bike_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyContext _context;

        public AdminController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bike_category(Bike_Detail details, IFormFile Image)
        {
            using MemoryStream Stream = new MemoryStream();
            if (Image != null)
            {
                Image.CopyTo(Stream);
                details.Image = Stream.ToArray();
            }
            _context.Bike_Details.Add(details);
            _context.SaveChanges();
            return View();
        }
    }
}
