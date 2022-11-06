using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.UpdateModel
{
    public class AccAndEqpUpdateModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AC { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
