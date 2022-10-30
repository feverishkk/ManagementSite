using CommonDatabase.Models;
using CommonDatabase.Models.Accessories;
using Management.Application.ViewModel.CommonDb.Customers;
using Management.Application.ViewModel.Customers;
using Management.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomersViewModel>> GetAllCustomers();
        Task<IEnumerable<CustomersInGameInfoViewModel>> CustomersInGameInfo(string userId);
        Task<IEnumerable<CustomerEquipmentViewModel>> CustomersEquipment(string userId);
    }
}