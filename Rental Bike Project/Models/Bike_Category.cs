using System.ComponentModel.DataAnnotations;

namespace Rental_Bike_Project.Models
{
    public class Bike_Category
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }
    }
}
