using System.ComponentModel.DataAnnotations;

namespace MiPark
{
    public class Car
    {
        [Key]
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Year { get; set; }
    }
}
