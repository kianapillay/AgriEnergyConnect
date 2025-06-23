using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyApp.Models
{
    public class Product
    {
        public int ProductId {get; set; }
        
        [Required(ErrorMessage = "Product Name is required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "ImageURL is required")]
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Production Date is required")]
        public DateTime ProductionDate { get; set; }
        
        public int FarmerId { get; set; }
        public Farmer? Farmer { get; set; }
    }
}