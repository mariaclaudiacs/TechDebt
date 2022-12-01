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

		public string Banco = string.Empty;
	}
}
