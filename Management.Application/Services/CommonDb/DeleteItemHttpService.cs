using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using Management.Application.Interfaces.CommonDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb
{
    public class DeleteItemHttpService : IDeleteItemHttpRepository
    {
        private readonly HttpClient _httpClient;
        public DeleteItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> DeleteBelt(int belt)
        {
            var response = await _httpClient.PostAsJsonAsync("/DeleteItem/DeleteBelt", belt);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteArmor(int armor)
        {
            var response = await _httpClient.PostAsJsonAsync("/DeleteItem/DeleteArmor", armor);
            return await response.Content.ReadAsStringAsync();
        }
        //public async Task<string> DeleteOneHandSword(OneHandSword oneHandSword)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/Delete/DeleteOneHandSword", oneHandSword.OneHandSwordId);
        //    return await response.Content.ReadAsStringAsync();
        //}
        public async Task<string> DeleteOneHandSword(int oneHandSword)
        {
            var response = await _httpClient.PostAsJsonAsync("/DeleteItem/DeleteOneHandSword", oneHandSword);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
