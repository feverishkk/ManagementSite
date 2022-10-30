using Management.Application.ViewModel.CommonDb.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.ViewModel.CommonDb.TotalItems
{
    public class TotalWeaponsViewModel
    {
        [Key]
        public int TotalWeaponId { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Damage1 { get; set; }
        public int Damage2 { get; set; }
        public string Class { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
