using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.Models;

namespace WebUI_BirDunyaAlisVeris.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //kayit islemleri
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(appUser, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
                else
                {
                    await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    return RedirectToAction("Index",controllerName:"Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            //await roleManager.CreateAsync(new AppRole {Name="AdminHelper" });
            //await roleManager.CreateAsync(new AppRole { Name = "Customer" });

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                TempData["returnUrl"] = ReturnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Kullanici Login ise birdaha login olmaya geldiginde cikisini yapip yeni bir cookie uretilir
                await signInManager.SignOutAsync();
                if (string.IsNullOrEmpty(TempData["returnUrl"]?.ToString()))
                {
                    return RedirectToAction("Index", controllerName: "Home");
                }
                var ReturnUrl = TempData["returnUrl"].ToString();
                //sifreyle zorunlu hale getirildi
                var result =  await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                return Redirect(ReturnUrl);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                //IsAuthenticated ise sistemden cikart
                await signInManager.SignOutAsync();
                return RedirectToAction("Index",controllerName:"Home");

            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
