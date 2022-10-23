using Management.Application.Dto.CommonDb.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.CommonDb.TotalItems
{
    public class TotalWeaponsDto
    {
        [Key]
        public int WeaponId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        //public DaggerDto Dagger { get; set; }

        //public OneHandBowDto OneHandBow { get; set; }
        //public OneHandStickDto OneHandStick { get; set; }
        //public OneHandSwordDto OneHandSword { get; set; }

        //public TwoHandBowDto TwoHandBow { get; set; }
        //public TwoHandStickDto TwoHandStick { get; set; }
        //public TwoHandSwordDto TwoHandSword { get; set; }
    }
}
