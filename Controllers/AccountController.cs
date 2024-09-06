// Manages user registration, login, and logout
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialMedia.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register (Optional, if handling form submission server-side)
        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            // Handle the registration logic here
            // This could call a service to create a new user with Firebase or another system
            return RedirectToAction("Login");
        }

        // POST: Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Clear session or authentication cookie
            HttpContext.Session.Clear(); // If using sessions

            // Redirect to login page after logout
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/LoggedOut
        [HttpGet]
        public IActionResult LoggedOut()
        {
            return View();
        }

        // GET: Account/AccessDenied (in case unauthorized access occurs)
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // Optionally, this can be used to check if user is authenticated (redirect if necessary)
        private bool IsUserAuthenticated()
        {
            // Check if user is authenticated by using HttpContext or Firebase token verification logic
            return HttpContext.User.Identity.IsAuthenticated;
        }
    }
}


