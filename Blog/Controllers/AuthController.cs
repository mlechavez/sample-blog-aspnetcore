using Blog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers {
    public class AuthController : Controller {
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager) {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "Invalid credentials");
                return View(vm);
            }

            var result = await this.signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);

            if (!result.Succeeded) {
                ModelState.AddModelError("", "Invalid credentials");
                return View(vm);
            }

            return Url.IsLocalUrl(vm.ReturnUrl)
              ? Redirect(vm.ReturnUrl)
              : RedirectToAction("index", "home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
