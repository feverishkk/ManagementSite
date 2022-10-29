using CommonDatabase.Models.Accessories;
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
    public class CreateItemService : ICreateItemRepository
    {
        private readonly HttpClient _httpClient;

        public CreateItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateAccItem(Belt arrayList)
        {
            var response = await _httpClient.PostAsJsonAsync("/Create/CreateAccItem", arrayList);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAccItem(int itemId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Create/DeleteAccItem", itemId);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
