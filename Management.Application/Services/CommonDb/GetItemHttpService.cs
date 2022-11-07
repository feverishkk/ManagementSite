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
        public async Task<IEnumerable<EarRing>> GetEarRing()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EarRing>>("GetItems/GetEarRing");
        }
        public async Task<IEnumerable<Neckless>> GetNeckless()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Neckless>>("GetItems/GetNeckless");
        }
        public async Task<IEnumerable<Ring1>> GetRing1()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Ring1>>("GetItems/GetRing1");
        }
        public async Task<IEnumerable<Ring2>> GetRing2()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Ring2>>("GetItems/GetRing2");
        }
        public async Task<IEnumerable<Boots>> GetBoots()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Boots>>("GetItems/GetBoots");
        }
        public async Task<IEnumerable<Cape>> GetCape()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Cape>>("GetItems/GetCape");
        }
        public async Task<IEnumerable<Globe>> GetGlobe()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Globe>>("GetItems/GetGlobe");
        }
        public async Task<IEnumerable<Guard>> GetGuard()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Guard>>("GetItems/GetGuard");
        }
        public async Task<IEnumerable<Helmet>> GetHelmet()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Helmet>>("GetItems/GetHelmet");
        }
        public async Task<IEnumerable<TShirt>> GetTShirt()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TShirt>>("GetItems/GetTShirt");
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
