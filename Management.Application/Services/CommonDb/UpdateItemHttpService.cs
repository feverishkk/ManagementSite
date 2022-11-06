using CommonDatabase.Models.Accessories;
using Management.Application.ViewModel.CommonDb.Customers;
using Management.Application.Interfaces.CommonDb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using CommonDatabase.Models.UpdateModel;
using CommonDatabase.Models.Customers;

namespace Management.Application.Services.CommonDb
{
    public class UpdateItemHttpService : IUpdateItemHttpRepository
    {
        private readonly HttpClient _httpClient;


        public UpdateItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccAndEqpUpdateModel> UpdateCustomerEquipment(ArrayList userInfo)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateCustomerEquipment", userInfo);
            return await response.Content.ReadFromJsonAsync<AccAndEqpUpdateModel>();
        }

        public async Task<TotalWeapons> UpdateCustomerWeapon(ArrayList userInfo)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateCustomerWeapon", userInfo);
            return await response.Content.ReadFromJsonAsync<TotalWeapons>();
        }

        public async Task<string> UpdateBelt(Belt belt)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateBelt", belt);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateArmor(Armor armor)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateArmor", armor);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateOneHandSword(OneHandSword oneHandSword)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateOneHandSword", oneHandSword);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
