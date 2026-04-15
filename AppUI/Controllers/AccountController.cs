using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository<UserInfo> _userRepo;

        public AccountController(IUserRepository<UserInfo> userRepo)
        {
            _userRepo = userRepo;
        }

        //  GET: Register Page
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register User
        [HttpPost]
        public async Task<IActionResult> Register(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                //  Check duplicate email
                var existingUser = await _userRepo.GetByEmail(model.EmailId);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View(model);
                }

                // Set role
                model.Role = "Participant";

                // Save to DB
                await _userRepo.Register(model);

                //  Redirect to login
                return RedirectToAction("Login");
            }

            return View(model);

        }


        public IActionResult Login() => View();

            [HttpPost]
            public async Task<IActionResult> Login(string email, string password)
            {
                var user = await _userRepo.GetByEmail(email);

                if (user != null && user.password == password)
                {
                    HttpContext.Session.SetString("UserEmail", email);
                    HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetString("UserEmail", user.EmailId);


                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");

                }
                else if (user.Role == "Participant")
                {

                    return RedirectToAction("Dashboard", "Participant");

                }
             }

                ViewBag.Error = "Invalid Login";
                return View();
            }

            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
        
    }
}
