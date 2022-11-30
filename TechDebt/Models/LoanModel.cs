﻿namespace TechDebt.Models
{
    public class LoanModel
    {
		// valor do perfee aqui, só para testes
		public double Perfee = 2.3;
		public double Valor { get; set; }
		public int Anos { get; set; }
		public double a { get; set; }
		public double b { get; set; }
		public double valorTotalPago { get; set; }
		public double valorParcela { get; set; }
		public double valorJuros { get; set; }

		public void Calculo()
		{
			a = 1 + (Perfee / 10);
			b = Math.Pow(a, Anos);
			valorTotalPago = b * Valor;
			valorParcela = valorTotalPago / (Anos * 12);
			valorJuros = valorTotalPago - Valor;
		}
	}
}
