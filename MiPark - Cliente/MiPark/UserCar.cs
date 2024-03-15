using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPark
{
    public class UserCar
    {
        [Key]
        [Column(Order = 0)]
        public required string UserID { get; set; }

        [Column(Order = 1)]
        public required string Plate { get; set; }

    }
}
