using CommonDatabase.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Customers
{
    public class CustomersEquipment
    {
        [Key]
        public int EquipementId { get; set; }
        public Weapon weapons { get; set; }
        /*
        public int Weapon { get; set; }
        public int TShirt { get; set; }
        public int Armor { get; set; }
        public int Cape { get; set; }
        public int Boots { get; set; }
        public int Globe { get; set; }
        public int Ring1 { get; set; }
        public int Ring2 { get; set; }
        public int Guard { get; set; }
        public int Helmet { get; set; }
        public int Belt { get; set; }
        public int EarRing { get; set; }
        */
    }
}
