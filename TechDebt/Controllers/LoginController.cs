using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;
using System;

namespace TechDebt.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar1(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        LoginControl._UserLogged = 1;
                        return RedirectToAction("Index", "Users");
                    }
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Entrar2(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        LoginControl._UserLogged = 1;
                        return RedirectToAction("Index", "Banks");
                    }
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}
