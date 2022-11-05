using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Management.Application.ViewModel.Accessories;
using Management.Application.ViewModel.CommonDb.Customers;
using Management.Application.ViewModel.CommonDb.TotalItems;
using Management.Application.Interfaces.CommonDb;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommonDatabase.Models.Equipment;

namespace Management.Application.Services.CommonDb
{
    public class GetItemHttpService : IGetItemHttpRepository
    {
        private readonly HttpClient _httpClient;

        public GetItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Belt>> GetBelt()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Belt>>("GetItems/GetBelt");
        }

        public async Task<IEnumerable<Armor>> GetArmor()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Armor>>("GetItems/GetArmor");
        }

        public async Task<IEnumerable<OneHandSword>> GetOneHandSword()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OneHandSword>>("GetItems/GetOneHandSword");
        }

        public async Task<IEnumerable<TotalWeapons>> GetAllWeapon()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TotalWeapons>>("GetItems/GetAllWeapons");
        }

        public async Task<IEnumerable<TotalEquipment>> GetAllEquipment()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TotalEquipment>>("GetItems/GetAllEquipment");
        }

        public async Task<IEnumerable<TotalAccessories>> GetAllAcc()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TotalAccessories>>("GetItems/GetAllAcc");
        }

    }
}
