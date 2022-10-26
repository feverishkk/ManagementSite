using CommonDatabase.Models.Accessories;
using Management.Application.Interfaces.CommonDb;
using Management.Application.Services.CommonDb.GenericService;
using ManagementDbContext.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb
{
    public class GetItemService : GenericService<Belt>, IGetItemRepository 
    {
        public GetItemService(CommonDbContext _commonDbContext) : base(_commonDbContext)
        {

        }

        public IEnumerable<Belt> GetItems()
        {
            //return (IEnumerable<Belt>)_commonDbContext.Belt.OrderByDescending(d => d.Name).ToList();
            throw new NotImplementedException();
        }

        IEnumerable<Belt> IGetItemRepository.GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
