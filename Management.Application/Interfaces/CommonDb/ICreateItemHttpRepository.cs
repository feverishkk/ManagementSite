using CommonDatabase.Models.Accessories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface ICreateItemHttpRepository
    {
        Task<string> CreateAccItem(Belt arrayList);
    }
}