﻿using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = TempData["Mail"];
            ViewBag.v = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var value = TempData["Mail"];
            var user = await _userManager.FindByEmailAsync(value.ToString());
            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                return RedirectToAction("Index","MyProfile");
            }
            return View();

        }
    }
}