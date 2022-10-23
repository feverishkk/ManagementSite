using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDatabase.Models.Customers
{
    public class CustomersEquipment
    {
        [Key]
        public int UserId { get; set; }

        public string ID { get; set; }
        
        //[ForeignKey("WeaponId")]
        public virtual TotalWeapons TotalWeapons { get; set; }

        //[ForeignKey("Id")]
        public virtual TShirt TShirt { get; set; }

        //[ForeignKey("Id")]
        public virtual Armor Armor { get; set; }

        //[ForeignKey("Id")]
        public virtual Cape Cape { get; set; }

        //[ForeignKey("Id")]
        public virtual Boots Boots { get; set; }

        //[ForeignKey("Id")]
        public virtual Globe Globe { get; set; }

        //[ForeignKey("Id")]
        public virtual Ring Ring1 { get; set; }

        //[ForeignKey("Id")]
        public virtual Ring Ring2 { get; set; }

        //[ForeignKey("Id")]
        public virtual Guard Guard { get; set; }

        //[ForeignKey("Id")]
        public virtual Helmet Helmet { get; set; }

        //[ForeignKey("Id")]
        public virtual Belt Belt { get; set; }

        //[ForeignKey("Id")]
        public virtual EarRing EarRing { get; set; }
    }

}
