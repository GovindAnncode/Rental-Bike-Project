using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental_Bike_Project.Models
{
    public class Bike_Detail
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Charges { get; set; }  

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int Cid { get; set; } 

        [ForeignKey("Cid")]  
        public Bike_Category Bike_Category { get; set; }
    }
}
