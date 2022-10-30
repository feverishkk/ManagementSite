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

namespace Management.Application.Services.CommonDb
{
    public class UpdateItemHttpService : IUpdateItemHttpRepository
    {
        private readonly HttpClient _httpClient;


        public UpdateItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Belt> UpdateCustomerEquipment(ArrayList userInfo)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateCustomerEquipment", userInfo);
            return await response.Content.ReadFromJsonAsync<Belt>();
        }

        public async Task<string> UpdateAccItem(Belt arrayList)
        {
            var response = await _httpClient.PostAsJsonAsync("/UpdateItems/UpdateAccItem", arrayList);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
