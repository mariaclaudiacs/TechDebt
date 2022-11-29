using TechDebt.Utils.Entities;

namespace TechDebt.Models
{
    public class ConsortiumsModel
    {
        public List<Consortium> GetConsortiums()
        {

            return Consortium.QuerryAll();  
        }
    }
}
