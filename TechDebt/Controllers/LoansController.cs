using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;
using TechDebt.Utils.Entities;
using static TechDebt.Utils.Entities.Loan;

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
            switch (loan.Modalidade)
            {
                case Modalidades.Pessoal:
                    loan.CalculoPerfee(loan);
                    break;

                case Modalidades.Veicular:
                    loan.CalculoVehfee(loan);
                    break;
            }
            return View(loan);
        }
    }
}
