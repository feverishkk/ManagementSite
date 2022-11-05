using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICreateItemHttpRepository
    {
        Task<string> CreateBelt(Belt belt);
        Task<string> CreateArmor(Armor armor);
        Task<string> CreateOneHandSword(OneHandSword oneHandSword);
    }
}