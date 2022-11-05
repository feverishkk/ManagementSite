using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using Management.Application.Interfaces.CommonDb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb
{
    public class CreateItemHttpService : ICreateItemHttpRepository
    {
        private readonly HttpClient _httpClient;

        public CreateItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateBelt(Belt belt)
        {
            var response = await _httpClient.PostAsJsonAsync("/CreateItem/CreateBelt", belt);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CreateArmor(Armor armor)
        {
            var response = await _httpClient.PostAsJsonAsync("/CreateItem/CreateArmor", armor);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CreateOneHandSword(OneHandSword oneHandSword)
        {
            var response = await _httpClient.PostAsJsonAsync("/CreateItem/CreateOneHandSword", oneHandSword);
            return await response.Content.ReadAsStringAsync();
        }
        
    }
}
