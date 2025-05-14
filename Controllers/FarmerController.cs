using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using AgriEnergyApp.Models;

public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;

    public FarmerController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Farmer/Create
    public IActionResult Create()
    {
        var role = HttpContext.Session.GetString("UserRole");

        if (role != "Employee")
        {
            return RedirectToAction("AccessDenied", "User");
        }

        return View();
    }

    // POST: Farmer/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FarmerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password cannot be null or empty.");
                return View(model);
            }

            var hasher = new PasswordHasher<User>();

            var newUser = new User
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                Role = "Farmer"
            };

            newUser.Password = hasher.HashPassword(newUser, model.Password); 

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var farmer = new Farmer
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                UserId = newUser.UserId
            };

            _context.Farmers.Add(farmer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(model);
    }

    // GET: Farmer/Index
    public IActionResult Index()
    {
        var farmers = _context.Farmers.ToList();
        return View(farmers);
    }
}
