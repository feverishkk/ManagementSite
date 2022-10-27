using CommonDatabase.Models.Customers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Accessories
{
    public class Belt
    {
        [Key]
        public int BeltId { get; set; } 
        public string Name { get; set; } 
        public int AC { get; set; }
        public string Class { get; set; } 
        public string Image { get; set; } 
        public string Description { get; set; }
    }
}
