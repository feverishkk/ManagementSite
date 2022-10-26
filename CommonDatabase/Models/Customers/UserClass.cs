using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public enum UserClass
    {
        [Display(Name = "군주")]
        Sovereign = 1,
        
        [Display(Name = "기사")]
        Knight,

        [Display(Name = "요정")]
        Elf,

        [Display(Name = "마법사")]
        Magician,

        [Display(Name = "다크엘프")]
        DarkElf,

        [Display(Name = "용기사")]
        DragonKnight,

        [Display(Name = "환술사")]
        Witchcraft,

        [Display(Name = "전사")]
        Warrior
    }
}
