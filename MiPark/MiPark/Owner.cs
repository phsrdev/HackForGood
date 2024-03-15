using System;
using System.Collections.Generic;

namespace MiPark
{
    public class Owner
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public string Password { get; set; }
        public List<Park> Parks { get; set; } = new List<Park>();
        public void AddPark(Park park)
        {
            Parks.Add(park);
        }
    }
}

