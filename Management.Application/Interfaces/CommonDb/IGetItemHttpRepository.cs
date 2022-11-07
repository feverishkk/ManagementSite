using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
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
        Task<IEnumerable<EarRing>> GetEarRing();
        Task<IEnumerable<Neckless>> GetNeckless();
        Task<IEnumerable<Ring1>> GetRing1();
        Task<IEnumerable<Ring2>> GetRing2();

        Task<IEnumerable<Boots>> GetBoots();
        Task<IEnumerable<Cape>> GetCape();
        Task<IEnumerable<Armor>> GetArmor();
        Task<IEnumerable<Globe>> GetGlobe();
        Task<IEnumerable<Guard>> GetGuard();
        Task<IEnumerable<Helmet>> GetHelmet();
        Task<IEnumerable<TShirt>> GetTShirt();

        Task<IEnumerable<OneHandSword>> GetOneHandSword();
    }
}