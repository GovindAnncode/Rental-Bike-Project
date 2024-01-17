using System.ComponentModel.DataAnnotations;

namespace Rental_Bike_Project.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
