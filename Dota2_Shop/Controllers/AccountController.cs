using Dota2_Shop.Date;
using Dota2_Shop.Date.ViewModels;
using Dota2_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dota2_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
           if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Items");
                    }
                }
                TempData["Error"] = "Wrong. Please, try again";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong. Please, try again";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());
    }
}
