using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class TotalWeapons
    {
        [Key]
        public int WeaponId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        //public Dagger Dagger { get; set; }

        //public OneHandBow OneHandBow { get; set; }
        //public OneHandStick OneHandStick { get; set; }
        //public OneHandSword OneHandSword { get; set; }  

        //public TwoHandBow TwoHandBow { get; set; }
        //public TwoHandStick TwoHandStick { get; set; }
        //public TwoHandSword TwoHandSword { get; set; }
        
    }
}
