using static TechDebt.Models.LoanModel;
using static TechDebt.Utils.Entities.Loan;

namespace TechDebt.Models
{
    public class LoanModel
    {
        public double PerfeeCaixa = 26;
		public double VehfeeCaixa = 18;

		public double PerfeeItau = 72;
		public double VehfeeItau = 23;

		public double PerfeeSantander = 77;
		public double VehfeeSantander = 17;

		public double PerfeeBradesco = 107;
		public double VehfeeBradesco = 24;
		public double Valor { get; set; }
		public int Anos { get; set; }
		public double a { get; set; }
		public double b { get; set; }
		public double valorTotalPago { get; set; }
		public double valorParcela { get; set; }
		public double valorJuros { get; set; }
		public Bancos Banco { get; set; }
		public Modalidades Modalidade { get; set; }

		public void CalculoPerfee(LoanModel loan)
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
        }
        public void CalculoVehfee(LoanModel loan)
        {
            switch (loan.Banco)
            {
                case Bancos.Caixa:
                    loan.a = 1 + (loan.VehfeeCaixa / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Itau:
                    loan.a = 1 + (loan.VehfeeItau / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Santander:
                    loan.a = 1 + (loan.VehfeeSantander / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;

                case Bancos.Bradesco:
                    loan.a = 1 + (loan.VehfeeBradesco / 100);
                    loan.b = Math.Pow(loan.a, loan.Anos);
                    loan.valorTotalPago = loan.b * loan.Valor;
                    loan.valorParcela = loan.valorTotalPago / (loan.Anos * 12);
                    loan.valorJuros = loan.valorTotalPago - loan.Valor;
                    break;
            }
        }
    }
}
