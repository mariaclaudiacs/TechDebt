using System.Xml.Linq;
using TechDebt.Utils.Entities;

namespace TechDebt.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public UserModel() { }
        public UserModel(User user)
        {
            Id = user.Id;
            Nome = user.Nome;
            Email = user.Email;
            Senha = user.Senha;
        }

        public User GenerateUser()
        {
            var result = new User()
            {
                Id = Id,
                Nome = Nome,
                Email = Email,
                Senha = Senha,
            };

            return result;
        }
    }

}
