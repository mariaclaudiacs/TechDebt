using TechDebt.Utils.Entities;

namespace TechDebt.Models
{
    public class UsersModel
    {
        public List<User> GetUsers()
        {
            return User.QuerryAll();
        }
    }
}
