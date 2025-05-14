using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyApp.Models
{
    public class Farmer
    {
        public int FarmerId {get; set; }
        public string? FirstName {get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }

        public int UserId { get; set; }
        public User? User {get; set; }
        public ICollection<Product>? Products {get; set; }
    }
}