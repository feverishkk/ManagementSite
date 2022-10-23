using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.CommonDb.Customers
{
    public class CustomersEquipmentDto
    {
        [Key]
        public int EquipementId { get; set; }
        public Weapon Weapon { get; set; }
        public TShirt TShirt { get; set; }
        public Armor Armor { get; set; }
        public Cape Cape { get; set; }
        public Boots Boots { get; set; }
        public Globe Globe { get; set; }
        public Ring Ring1 { get; set; }
        public Ring Ring2 { get; set; }
        public Guard Guard { get; set; }
        public Helmet Helmet { get; set; }
        public Belt Belt { get; set; }
        public EarRing EarRing { get; set; }
    }
}
