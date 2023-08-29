using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }
            await _signInManager.PasswordSignInAsync(userLoginData.Username, userLoginData.Password, false, false);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Register(register userRegisterData)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterData);
            }
            var newUser = new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.Username
            };
            await _userManager.CreateAsync(newUser, userRegisterData.Password);

            return RedirectToAction("choosenews", "Home");


        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
       
    }
}
