using CommonDatabase.Models.Customers;
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
    public class ChartService : IChartRepository
    {
        private readonly HttpClient _httpClient;

        public ChartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double[]> GetUserClassChart()
        {
            return await _httpClient.GetFromJsonAsync<double[]>("/Chart/GetUserClassChart");
        }

        public async Task<double[]> GetUserGenderChart()
        {
            return await _httpClient.GetFromJsonAsync<double[]>("/Chart/GetUserGenderChart");
        }

        public async Task<double[]> GetWhoIsTheHighPaidCash()
        {
            return await _httpClient.GetFromJsonAsync<double[]>("/Chart/GetWhoIsTheHighPaidCash");
        }

        public async Task<double[]> GetActiveUsers()
        {
            return await _httpClient.GetFromJsonAsync<double[]>("/Chart/GetActiveUsers");
        }

    }
}
