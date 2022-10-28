using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class TotalWeapon
    {
        public virtual Dagger Dagger { get; set; }

        public virtual OneHandBow OneHandBow { get; set; }
        public virtual OneHandStick OneHandStick { get; set; }
        public virtual OneHandSword OneHandSword { get; set; }
        
        public virtual TwoHandBow TwoHandBow { get; set; }
        public virtual TwoHandStick TwoHandStick { get; set; }
        public virtual TwoHandSword TwoHandSword { get; set; }

    }
}
