using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;
using TechDebt.Utils.Entities;

namespace TechDebt.Controllers
{
    public class BanksController : Controller
    {
        public IActionResult Index()
        {
            if (LoginControl._UserLogged == 0)
            {
                return RedirectToAction("Index", "Login2");
            }
            else
            {
                var model = new BanksModel();
                return View(model);
            }
        }

        public IActionResult AddBank()
        {
            var model = new BanksModel();
            return View();
        }

        [HttpPost]
        public IActionResult AddBank(BankModel bankModel)
        {
            var bank = new Bank()
            {
                Id = bankModel.Id,
                Nome = bankModel.Nome,
                Perfee = bankModel.Perfee,
                VehFee = bankModel.VehFee,
            };
           // Criar Usuário
            bank.Create();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateBank(int id)
        {
            var bank = new Bank(id);
            var model = new BankModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBank(BankModel model)
        {
            var bank = model.GenerateBank();
            bank.Update();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBank(int id)
        {
            var bank = new Bank(id);
            var model = new BankModel(bank);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteBank(BankModel model)
        {
            var bank = model.GenerateBank();
            bank.Delete();

            return RedirectToAction("Index");
        }
    }
}
