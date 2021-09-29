using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmaDotCom.Models;
using Microsoft.AspNetCore.Identity;

namespace PharmaDotCom.Controllers
{
    public class AdminLoginController : Controller
    {
       
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminLoginController(SignInManager<IdentityUser> signInManager)
        {
            
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public  IActionResult Index(AdminSignIn adminSignIn)
        {

            adminSignIn.Email = "Admin@gmail.com";
            adminSignIn.Password = "Admin";
           
            {
                return RedirectToAction("Index", "Dashboard");
            }


            
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "AdminLogin");
        }
    }
}
