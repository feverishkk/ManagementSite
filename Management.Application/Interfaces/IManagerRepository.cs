using Management.Application.ViewModel.Managers;
using Management.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<ManagersViewModel>> GetAllManagers();
        Task<ManagerResult> GetManagersInfo(string userId);
        Task<ManagerResult> DeleteManager(string userId);
        Task<ManagerResult> GetUserRole(string userId);
        Task<ManagerResult> UpdateManagerRole(ArrayList managerRoleDto);
        Task<ManagerResult> UpdateManagerInfo(UpdateManagerInfoViewModel managerInfoDto);
    }
}