using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLogin.Models;

namespace RegisterAndLogin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private LoginContext _context;

    public HomeController(ILogger<HomeController> logger, LoginContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        HttpContext.Session.SetString("ValidationSummary", "RegisterForm");
        if (ModelState.IsValid)
        {
            
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            _context.Add(user);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", user.IdUser);
            
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginUser userSubmission)
    {   
        HttpContext.Session.SetString("ValidationSummary", "LoginForm");
        if (ModelState.IsValid)
        {
            
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
            if (userInDb == null)
            {
                
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            var hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
            if (result == 0)
            {
                
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.IdUser);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [SessionCheck]
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.Session.Remove("UserId");
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
