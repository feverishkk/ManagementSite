using CommonDatabase.Models.Accessories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICreateItemRepository
    {
        Task<string> CreateAccItem(Belt arrayList);
        Task<string> DeleteAccItem(int itemId);
    }
}