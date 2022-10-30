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
        Task<IEnumerable<CustomerTotalWeapons>> GetAllWeapon();
        Task<IEnumerable<Belt>> GetBelt();
        Task<IEnumerable<EarRing>> GetEarRings();
    }
}