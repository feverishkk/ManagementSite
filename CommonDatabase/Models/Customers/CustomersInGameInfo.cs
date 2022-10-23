using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public class CustomersInGameInfo
    {
        [Key]
        public int UserId { get; set; }
        public int UserClass { get; set; }
        public string GuildName { get; set; } = string.Empty;
        public CustomersEquipment CustomersEquipments { get; set; }
    }
}
