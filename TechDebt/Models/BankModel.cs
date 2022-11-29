using TechDebt.Utils.Entities;

namespace TechDebt.Models
{
    public class BankModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Perfee { get; set; }

        public double VehFee { get; set; }

        public BankModel() { }
        public BankModel(Bank bank)
        {
            Id = bank.Id;
            Nome = bank.Nome;
            Perfee = bank.Perfee;
            VehFee = bank.VehFee;
        
        }

        public Bank GenerateBank()
        {
            var result = new Bank()
            {
                Id = Id,
                Nome = Nome,
                Perfee = Perfee,
                VehFee = VehFee
            };

            return result;
        }
    }
}
