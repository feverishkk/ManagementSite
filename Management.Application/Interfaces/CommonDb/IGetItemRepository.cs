using CommonDatabase.Models.Accessories;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IGetItemRepository : IGenericRepository<Belt> 
    {
        IEnumerable<Belt> GetItems();
    }
}
