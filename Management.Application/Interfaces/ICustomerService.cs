using CommonDatabase.Models;
using Management.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        //Task<IEnumerable<ApplicationUser>> GetAllCustomers();
    }
}