using CommonDatabase.Models;
using CommonDatabase.Models.Accessories;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Dto.Customers;
using Management.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomersDto>> GetAllCustomers();
        Task<IEnumerable<CustomersInGameInfoDto>> CustomersInGameInfo(string userId);
        Task<IEnumerable<CustomerEquipmentDto>> CustomersEquipment(string userId);
        //Task<CustomerEquipmentDto> UpdateCustomerEquipment(CustomerEquipmentDto customerEquipment);
        Task<Belt> UpdateCustomerEquipment(ArrayList userInfo);
    }
}