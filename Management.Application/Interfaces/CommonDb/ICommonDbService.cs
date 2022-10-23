using CommonDatabase.Models.TotalItems;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.CommonDb.TotalItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICommonDbService
    {
        Task<IEnumerable<TotalWeaponsDto>> GetAllWeapon();
    }
}