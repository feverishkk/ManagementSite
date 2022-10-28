using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Management.Application.Dto.Accessories;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.CommonDb.TotalItems;
using Management.Application.Interfaces.CommonDb;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb
{
    public class CommonDbService : ICommonDbRepository
    {
        private readonly HttpClient _httpClient;

        public CommonDbService(HttpClient httpClient)
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

        public async Task<IEnumerable<Acc>> GetAcc()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Acc>>("GetItems/GetAcc");
        }

        public async Task<IEnumerable<CustomerTotalWeapons>> GetAllWeapon()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerTotalWeapons>>("GetItems/GetAllWeapons");
        }




    }
}
