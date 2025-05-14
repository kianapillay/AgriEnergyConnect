using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyApp.Models;

public class ProductFilterViewModel
{
    public string? SearchTerm { get; set; }
    public string? Category { get; set; }
    public List<Product>? Products { get; set; }
}
