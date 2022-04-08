using Microsoft.AspNetCore.Mvc;
using SmartVet.Helpers;
using SmartVet.Models;

namespace SmartVet.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountsController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public IActionResult Login()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o Contraseña incorrectos,");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout() 
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
