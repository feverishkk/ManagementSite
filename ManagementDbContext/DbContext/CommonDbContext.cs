using CommonDatabase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementDbContext.DbContext
{
    /// <summary>
    /// 고객들을 관리하는 Context
    /// </summary>
    public class CommonDbContext : IdentityDbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; } = default;
    }
}
