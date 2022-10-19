using Management.Application.Dto.Managers;
using Management.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ApplicationUser>> GetAllManagers();
        Task<ManagerResult> DeleteManager(string userId);
        Task<ManagerResult> GetUserRole(string userId);
        //Task<ApplicationUser> GetUserRole(string userId);
        //Task<ManagerResult> UpdateManagerRole(string userId, UpdateManagerRoleDto managerRoleDto);
        Task<ManagerResult> UpdateManagerRole(ArrayList managerRoleDto);
    }
}