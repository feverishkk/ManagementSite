﻿using Management.Application.Dto.Managers;
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
    public class ManagerService : IManagerService
    {
        private readonly HttpClient _httpClient;

        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllManagers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ApplicationUser>>("/Manager/GetAllManagers");
        }

        public async Task<ManagerResult> DeleteManager(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/DeleteManager", userId);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

    }
}
