using RentalBikeProject.Migrations;

namespace Rental_Bike_Project.Models
{
    public class BikeViewModel
    {
        public List<Bike_Category> Categories { get; set; }
        public List<Bike_Detail> Bikes { get; set; }
    }
}
