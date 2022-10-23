using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Accessories
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public string AC { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
