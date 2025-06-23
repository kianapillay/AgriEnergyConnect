using System.ComponentModel.DataAnnotations;

public class User
{
    public int UserId { get; set; }

    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public string? Role { get; set; } 
}