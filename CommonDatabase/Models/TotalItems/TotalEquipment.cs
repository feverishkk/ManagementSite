using CommonDatabase.Models.Equipment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class TotalEquipment
    {
        [Key]
        public int TotalEqpId { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int AC { get; set; } 
        public string Class { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
