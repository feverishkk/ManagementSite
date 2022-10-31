using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.TotalItems;
using Management.Application.ViewModel.CommonDb.Customers;
using Management.Application.ViewModel.CommonDb.TotalItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IGetItemHttpRepository
    {
        Task<IEnumerable<TotalWeapons>> GetAllWeapon();
        Task<IEnumerable<TotalEquipment>> GetAllEquipment();
        Task<IEnumerable<TotalAccessories>> GetAllAcc();
        Task<IEnumerable<Belt>> GetBelt();
        Task<IEnumerable<EarRing>> GetEarRings();
    }
}