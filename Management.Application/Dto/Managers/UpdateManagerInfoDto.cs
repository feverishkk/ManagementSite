﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.Managers
{
    public class UpdateManagerInfoDto
    {
        public string UserId { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Department { get; set; }
        public string DepartmentNumber { get; set; }

    }
}
