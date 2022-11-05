using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using Management.Application.ViewModel.CommonDb.Customers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IUpdateItemHttpRepository
    {
        Task<Belt> UpdateCustomerEquipment(ArrayList userInfo);


        Task<string> UpdateBelt(Belt belt);
        Task<string> UpdateArmor(Armor armor);
        Task<string> UpdateOneHandSword(OneHandSword oneHandSword);
    }
}