using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			//Birinci ture değeri kullanıcı hatırlasın mı. İkinci true değeri 5 kere yanlış girerse hesap kitlensin mi?
			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, true);

            if (result.Succeeded)
            {
				return RedirectToAction("Index", "Category");
            }

            return View();
		}
	}
}
