using CommonDatabase.Models.Accessories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICreateItemRepository
    {
        //Task<Belt> CreateAccItem(ArrayList arrayList);
        Task<Belt> CreateAccItem(Belt arrayList);
        Task<Belt> DeleteAccItem(int itemId);
    }
}