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
            ModelState.Clear();
            loan.a = 1 + (loan.Perfee / 10);
            loan.b = Math.Pow(loan.a, loan.Anos);
            loan.valorTotalPago = loan.b * loan.Valor;
            loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
            loan.valorJuros = loan.valorTotalPago - loan.Valor;
            return View(loan);
        }


    }
}
