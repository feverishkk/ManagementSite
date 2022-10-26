using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.TotalItems;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.CommonDb.TotalItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICommonDbRepository
    {
        //Task<IEnumerable<TotalWeaponsDto>> GetAllWeapon();
        Task<IEnumerable<Belt>> GetBelt();
        Task<IEnumerable<EarRing>> GetEarRings();
        Task<IEnumerable<Acc>> GetAcc();
    }
}