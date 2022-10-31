using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDatabase.Models.Customers
{
    public class CustomerEquipment
    {
        [Key]
        public int UserId { get; set; }

        public string ID { get; set; }

        [ForeignKey("TotalWeaponId")]
        public virtual TotalWeapons TotalWeapons { get; set; } 

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
