using Management.Application.Dto.CommonDb.Customers;
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
    public class UpdateItemService : IUpdateItemService
    {
        private readonly HttpClient _httpClient;


        public UpdateItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<CustomerEquipmentDto>> UpdateCustomerEquipment(string userId, int beltId)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<CustomerEquipmentDto>> UpdateCustomerEquipment(string userId, int beltId)
        //{
        //    return await _httpClient.PostAsJsonAsync<IEnumerable<CustomerEquipmentDto>>($"/Items/UpdateBelt?userId={userId}", beltId);
        //}


    }
}
