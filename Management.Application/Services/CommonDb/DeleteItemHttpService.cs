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

        public async Task<string> DeleteAccItem(int itemId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Delete/DeleteAccItem", itemId);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
