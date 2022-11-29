using TechDebt.Utils.Entities;

namespace TechDebt.Models
{   
    public enum Category
    {
        Imovel,
        Automovel, 
        Eletrodomestico,
        ContratacaoDeServicos,
    }
    public class ConsortiumModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string BornBirth { get; set; }
        public string Category { get; set; }
        
        public ConsortiumModel(Consortium user)
        {
            Name= user.Name;
            Number= user.Number;
            Email= user.Email;
            CEP= user.CEP;
            CPF= user.CPF;
            BornBirth = user.BornBirth;
            Category = user.Category;
        }

        public Consortium GenerateConsort()
        {
            var consort = new Consortium() 
            {
                Name = Name,
                Number = Number,
                Email = Email,
                CEP = CEP,
                CPF = CPF,
                BornBirth = BornBirth,
                Category = Category

            };

            return consort;
        }

    }
}
