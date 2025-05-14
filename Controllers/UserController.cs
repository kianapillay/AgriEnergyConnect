using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using AgriEnergyApp.Models;
using Microsoft.AspNetCore.Identity;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: User/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: User/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(user);
            }
            
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "Password cannot be empty.");
                return View(user);
            }
            
            user.Password = HashPassword(user.Password);
            user.Role = "Employee"; 
            
            _context.Users.Add(user);
            _context.SaveChanges();
            
            return RedirectToAction("Login");
        }
        return View(user);
}


    // GET: User/Login
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    // POST: User/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user == null || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(user.Password) || !VerifyPassword(model.Password, user.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            SetSession(HttpContext.Session, "UserRole", user.Role);
            SetSession(HttpContext.Session, "UserEmail", user.Email);
            SetSession(HttpContext.Session, "UserName", user.FirstName);

            if (user.Role == "Farmer")
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == user.UserId);
                if (farmer != null)
                {
                    HttpContext.Session.SetInt32("FarmerId", farmer.FarmerId);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        return View(model); 
    }

    // GET: User/Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    // GET: User/AccessDenied
    public IActionResult AccessDenied()
    {
        return View();
    }

    // Password hashing
    private string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException(nameof(password));
        }

        return _passwordHasher.HashPassword(null, password);
    }

    private bool VerifyPassword(string inputPassword, string storedHashedPassword)
    {
        if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedHashedPassword))
        {
            throw new ArgumentNullException(inputPassword == null ? nameof(inputPassword) : nameof(storedHashedPassword));
        }

        var result = _passwordHasher.VerifyHashedPassword(null, storedHashedPassword, inputPassword);
        return result == PasswordVerificationResult.Success;
    }

    public void SetSession(ISession session, string key, string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        session.SetString(key, value);
    }
}
