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
            switch (loan.Banco)
            {
                case Bancos.Caixa:
                    loan.a = 1 + (loan.PerfeeCaixa / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Itau:
                    loan.a = 1 + (loan.PerfeeItau / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Santander:
                    loan.a = 1 + (loan.PerfeeSantander / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Bradesco:
                    loan.a = 1 + (loan.PerfeeBradesco / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;
            }
            return View(loan);
        }
    }
}
