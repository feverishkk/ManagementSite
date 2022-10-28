using CommonDatabase.Models.Accessories;
using Management.Application.Dto.CommonDb.Customers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IUpdateItemRepository
    {
        Task<Belt> UpdateCustomerEquipment(ArrayList userInfo);
    }
}