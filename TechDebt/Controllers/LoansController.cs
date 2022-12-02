using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;

namespace TechDebt.Controllers
{
    public class LoansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult Simulador()
        {
            var model = new LoanModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Simulador(LoanModel loan)
        {
            loan.Calculo();
            return View(loan);
        }


    }
}
