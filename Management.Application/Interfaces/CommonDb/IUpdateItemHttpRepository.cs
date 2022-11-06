using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.UpdateModel;
using CommonDatabase.Models.Weapons;
using Management.Application.ViewModel.CommonDb.Customers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IUpdateItemHttpRepository
    {
        Task<AccAndEqpUpdateModel> UpdateCustomerEquipment(ArrayList userInfo);
        Task<TotalWeapons> UpdateCustomerWeapon(ArrayList userInfo);

        Task<string> UpdateBelt(Belt belt);
        Task<string> UpdateArmor(Armor armor);
        Task<string> UpdateOneHandSword(OneHandSword oneHandSword);
    }
}