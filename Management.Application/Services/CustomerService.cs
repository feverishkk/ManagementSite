﻿using CommonDatabase.Models.Accessories;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.Customers;
using Management.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class CustomerService : ICustomerRepository
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomersDto>> GetAllCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomersDto>>("Customers/GetAllCustomers");
        }

        public async Task<IEnumerable<CustomersInGameInfoDto>> CustomersInGameInfo(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomersInGameInfoDto>>("Customers/GetCustomersInGameInfo?userId=" + userId);
        }

        public async Task<IEnumerable<CustomerEquipmentDto>> CustomersEquipment(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerEquipmentDto>>("Customers/GetCustomerEquipment?userId=" + userId);
        }

        //public async Task<CustomerEquipmentDto> UpdateCustomerEquipment(CustomerEquipmentDto customerEquipment)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/Customers/UpdateCustomerEquipment", customerEquipment);
        //    return await response.Content.ReadFromJsonAsync<CustomerEquipmentDto>();
        //}

        public async Task<Belt> UpdateCustomerEquipment(ArrayList userInfo)
        {
            var response = await _httpClient.PostAsJsonAsync("/Customers/UpdateCustomerEquipment", userInfo);
            return await response.Content.ReadFromJsonAsync<Belt>();
        }

    }
}
