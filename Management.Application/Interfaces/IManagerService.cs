using Management.Application.Dto.Managers;
using Management.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ApplicationUser>> GetAllManagers();
    }
}