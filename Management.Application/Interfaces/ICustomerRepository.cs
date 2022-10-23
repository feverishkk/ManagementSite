using CommonDatabase.Models;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.Customers;
using Management.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomersDto>> GetAllCustomers();
        Task<IEnumerable<CustomersInGameInfoDto>> CustomersInGameInfo(string userId);
        Task<IEnumerable<CustomerEquipmentDto>> CustomersEquipment(string userId);
    }
}