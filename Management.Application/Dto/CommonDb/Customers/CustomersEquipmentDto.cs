using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.CommonDb.Customers
{
    public class CustomerEquipmentDto
    {
        [Key]
        public int UserId { get; set; }

        public string ID { get; set; }

        [ForeignKey("TotalWeaponId")]
        public virtual CustomerTotalWeapons TotalWeapons { get; set; } 

        public virtual TShirt TShirt { get; set; } 

        public virtual Armor Armor { get; set; }

        public virtual Cape Cape { get; set; } 

        public virtual Boots Boots { get; set; } 

        public virtual Globe Globe { get; set; }

        public virtual Ring1 Ring1 { get; set; } 

        public virtual Ring2 Ring2 { get; set; } 

        public virtual Neckless Neckless { get; set; } 

        public virtual Guard Guard { get; set; } 

        public virtual Helmet Helmet { get; set; } 

        public virtual Belt Belt { get; set; } 

        public virtual EarRing EarRing { get; set; }
    }
}

