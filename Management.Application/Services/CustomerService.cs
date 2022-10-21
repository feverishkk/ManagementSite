using CommonDatabase.Models;
using Management.Application.Interfaces;
using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customers>>("Customers/GetAllCustomers");
        }
    }
}
