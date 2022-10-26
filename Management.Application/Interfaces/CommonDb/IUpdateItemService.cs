using Management.Application.Dto.CommonDb.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IUpdateItemService
    {
        Task<IEnumerable<CustomerEquipmentDto>> UpdateCustomerEquipment(string userId, int beltId);
    }
}