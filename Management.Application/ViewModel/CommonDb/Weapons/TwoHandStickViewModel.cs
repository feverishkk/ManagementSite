using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.ViewModel.CommonDb.Weapons
{
    public class TwoHandStickViewModel
    {
        [Key]
        public int WeaponId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Damage1 { get; set; }
        public int Damage2 { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
    }
}
