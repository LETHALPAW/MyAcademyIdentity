using EmailApp.Entities;
using EmailApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
	public class LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				ModelState.AddModelError("","Email sistemde yok");
				return View(model);
			}
			var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Email veya parola hatalı");
				return View(model);
			}
			return RedirectToAction("Index", "Message");
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
