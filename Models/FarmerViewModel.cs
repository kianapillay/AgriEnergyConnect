using System.ComponentModel.DataAnnotations;

namespace AgriEnergyApp.Models;

public class FarmerViewModel
{
    public int FarmerId {get; set; }
    public string? FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; } 
    public string? Password { get; set; } 

    public int UserId { get; set; } 
}