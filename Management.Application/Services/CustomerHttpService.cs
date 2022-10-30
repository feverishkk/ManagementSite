using CommonDatabase.Models.Accessories;
using Management.Application.ViewModel.CommonDb.Customers;
using Management.Application.ViewModel.Customers;
using Management.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class CustomerHttpService : ICustomerHttpRepository
    {
        private readonly HttpClient _httpClient;

        public CustomerHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomersViewModel>> GetAllCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomersViewModel>>("Customers/GetAllCustomers");
        }

        public async Task<IEnumerable<CustomersInGameInfoViewModel>> CustomersInGameInfo(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomersInGameInfoViewModel>>("Customers/GetCustomersInGameInfo?userId=" + userId);
        }

        public async Task<IEnumerable<CustomerEquipmentViewModel>> CustomersEquipment(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerEquipmentViewModel>>("Customers/GetCustomerEquipment?userId=" + userId);
        }

    }
}
