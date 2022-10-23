using CommonDatabase.Models;
using Management.Application.Dto.Customers;
using Management.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomersDto>> GetAllCustomers();
    }
}