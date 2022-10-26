using CommonDatabase.Models.Accessories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class Acc
    {
        public virtual Belt Belt { get; set; }
        public virtual EarRing EarRing { get; set; }
        public virtual Neckless Neckless { get; set; }  
        public virtual Ring1 Ring1 { get; set; }
        public virtual Ring2 Ring2 { get; set; }
    }
}
