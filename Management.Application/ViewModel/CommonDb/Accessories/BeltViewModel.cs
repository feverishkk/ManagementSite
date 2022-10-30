using Management.Application.ViewModel.CommonDb.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.ViewModel.Accessories
{
    public class BeltViewModel
    {
        public string Name { get; set; }
        public string AC { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<CustomerEquipmentDto> customerEquipmentDto { get; set; }
    }
}
