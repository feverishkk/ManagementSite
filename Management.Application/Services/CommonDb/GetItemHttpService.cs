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

        public async Task<IEnumerable<EarRing>> GetEarRings()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EarRing>>("GetItems/GetEarRings");
        }

        public async Task<IEnumerable<CustomerTotalWeapons>> GetAllWeapon()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerTotalWeapons>>("GetItems/GetAllWeapons");
        }




    }
}
