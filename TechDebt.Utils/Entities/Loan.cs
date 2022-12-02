using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDebt.Utils.Entities
{
    public class Loan
    {
        public enum Bancos
        {
            Caixa = 10,
            Itau = 20,
            Santander = 30,
            Bradesco = 40,
        }

        public enum Modalidades
        {
            Pessoal = 1,
            Veicular = 2,
        }
    }
}
