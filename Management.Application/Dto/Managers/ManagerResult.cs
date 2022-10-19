using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.Managers
{
    public class ManagerResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }  
        public string Roles { get; set; }

        public ApplicationUser AppUsers { get; set; }
    }
}
