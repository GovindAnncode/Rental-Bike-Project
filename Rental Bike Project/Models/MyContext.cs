using Microsoft.EntityFrameworkCore;

namespace Rental_Bike_Project.Models
{
    public class MyContext : DbContext
    {
      
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Bike_Category> Bike_Categories { get; set; }

        public DbSet<Bike_Detail> Bike_Details { get; set;}

        public DbSet<SignUpModel> RegisterUers { get; set; }

        public DbSet<LoginModel> LoginModels { get; set; }




    }
}
