using BlogProjectExam.Models.Data;
using BlogProjectExam.Models.Entity;
using BlogProjectExam.ViewModels.Auth.Login;
using BlogProjectExam.ViewModels.Auth.Register;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectExam.Controllers
{
    public class AuthController : Controller
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login(string aktar)
        {
            ViewBag.aktar = aktar;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model, string aktar) 
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));

                if (user != null)
                {
                    HttpContext.Session.SetString("userId", user.Id.ToString());
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetString("username", user.Username);

                    if (string.IsNullOrEmpty(aktar))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else return Redirect(aktar);
                }
                else ModelState.AddModelError("", "This user can not be found");
            }
            else ModelState.AddModelError("", "Please fill all required fields");
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }

        public IActionResult Register() => View();
        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if(ModelState.IsValid)
            {
                if (!_context.Users.Any(x => x.Email.ToLower().Equals(user.Email.ToLower())))
                {

                    User newUser = new User(user.Name, user.LastName, user.Username, user.Email, user.Password);
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    TempData["message"] = "Registered Successfully";
                    return RedirectToAction("Login");
                }
                else ModelState.AddModelError("", "This user is already exists");
            }
            return View();
        }
    }
}
