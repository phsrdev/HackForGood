using System.ComponentModel.DataAnnotations;

namespace MiPark
{
    public class User
    {
        [Key]
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Surname { get; set; }
        public required string Password { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public required string DNI { get; set; }
    }
}
