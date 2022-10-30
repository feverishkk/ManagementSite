using CommonDatabase.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.ViewModel.CommonDb.Customers
{
    public class CustomersInGameInfoViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string ID { get; set; }
        public string UserName { get; set; }
        public UserClass UserClass { get; set; }
        public string GuildName { get; set; } = string.Empty;
    }
}
