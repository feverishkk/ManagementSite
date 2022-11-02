using Management.Application.ViewModel.Managers;
using Management.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class ManagerHttpService : IManagerHttpRepository
    {
        private readonly HttpClient _httpClient;

        public ManagerHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ManagersViewModel>> GetAllManagers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ManagersViewModel>>("/Manager/GetAllManagers");
        }

        public async Task<ManagerResult> GetManagersInfo(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/GetManagersInfo", userId);
            return await response.Content.ReadFromJsonAsync<ManagerResult>();
        }

        public async Task<ManagerResult> UpdateManagerInfo(UpdateManagerInfoViewModel managerInfoViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/Manager/UpdateManagerInfo", managerInfoViewModel);
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
