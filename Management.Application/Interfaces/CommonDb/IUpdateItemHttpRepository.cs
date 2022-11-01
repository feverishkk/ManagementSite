using CommonDatabase.Models.Accessories;
using Management.Application.ViewModel.CommonDb.Customers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IUpdateItemHttpRepository
    {
        Task<Belt> UpdateCustomerEquipment(ArrayList userInfo);
        Task<string> UpdateAccItem(Belt arrayList);
    }
}