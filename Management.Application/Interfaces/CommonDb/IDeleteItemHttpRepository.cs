using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IDeleteItemHttpRepository
    {
        Task<string> DeleteBelt(int itemId);
        Task<string> DeleteArmor(int itemId);
        //Task<string> DeleteOneHandSword(OneHandSword itemId);
        Task<string> DeleteOneHandSword(int oneHandSword);
    }
}