using Management.Application.Dto.Managers;
using Management.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<IEnumerable<ManagersDto>> GetAllManagers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ManagersDto>>("/Manager/GetAllManagers");
        }

        public async Task<ManagerResult> GetManagersInfo(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/GetManagersInfo", userId);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

        public async Task<ManagerResult> UpdateManagerInfo(UpdateManagerInfoDto managerInfoDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/UpdateManagerInfo", managerInfoDto);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

        public async Task<ManagerResult> DeleteManager(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/DeleteManager", userId);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

        public async Task<ManagerResult> GetUserRole(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/GetUserRole", userId);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

        public async Task<ManagerResult> UpdateManagerRole(ArrayList managerRoleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/UpdateManagerRole", managerRoleDto);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

    }
}
