using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AgriEnergyApp.Models;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Product/Create 
    public IActionResult Create()
    {
        var role = HttpContext.Session.GetString("UserRole");
        if (role != "Farmer")
        {
            return RedirectToAction("AccessDenied", "User");
        }

        return View();
    }

    // GET: Product/Index 
    public IActionResult Index()
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (farmerId == null)
        {
            return RedirectToAction("Login", "User");
        }

        var products = _context.Products
            .Where(p => p.FarmerId == farmerId.Value)
            .ToList();

        return View(products);
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");

        if (ModelState.IsValid && farmerId.HasValue)
        {
            product.FarmerId = farmerId.Value;
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: Product/Edit
    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Product/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ProductionDate = product.ProductionDate;
            existingProduct.ImageURL = product.ImageURL;

            try
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating product: " + ex.Message);
            }
        }

        return View(product);
    }

    // GET: Product/Delete
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Product/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    // GET: Product/AllProducts
    public IActionResult AllProducts(DateTime? startDate, DateTime? endDate, string category, int? farmerId)
    {
        var role = HttpContext.Session.GetString("UserRole");

        if (role != "Employee")
        {
            return RedirectToAction("AccessDenied", "User");
        }

        var products = _context.Products.AsQueryable();

        if (farmerId.HasValue)
        {
            products = products.Where(p => p.FarmerId == farmerId.Value);
        }

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Where(p => p.Category == category);
        }

        if (startDate.HasValue)
        {
            products = products.Where(p => p.ProductionDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            products = products.Where(p => p.ProductionDate <= endDate.Value);
        }

        ViewBag.Categories = _context.Products
            .Select(p => p.Category)
            .Distinct()
            .ToList();

        return View(products.ToList());
    }
}
