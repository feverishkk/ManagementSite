using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.CommonDb.TotalItems;
using Management.Application.Interfaces.CommonDb;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb
{
    public class CommonDbService : ICommonDbService
    {
        private readonly HttpClient _httpClient;

        public CommonDbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TotalWeaponsDto>> GetAllWeapon()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TotalWeaponsDto>>("Weapon/GetAllWeapons");
        }

        


    }
}
