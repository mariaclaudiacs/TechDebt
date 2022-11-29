using TechDebt.Utils.Entities;

namespace TechDebt.Models
{
    public class BanksModel
    {
 
            public List<Bank> GetBanks()
            {
                return Bank.QuerryAll();
            }
       
    }
}
