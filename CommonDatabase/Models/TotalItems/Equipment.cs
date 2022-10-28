using CommonDatabase.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class Equipment
    {
        public virtual Armor Armor { get; set; }
        public virtual Boots Boots { get; set; }
        public virtual Cape Cape { get; set; }  
        public virtual Globe Globe { get; set; }
        public virtual Guard Guard { get; set; }
        public virtual Helmet Helmet { get; set; }
        public virtual TShirt TShirt { get; set; }
    }
}
