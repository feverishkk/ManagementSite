using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Enums.Roles
{
    public enum RoleList
    {
        [EnumMember(Value = "SuperAdministrator")]
        SuperAdministrator = 0,

        [EnumMember(Value = "ServerAdministrator")]
        ServerAdministrator,

        [EnumMember(Value = "Basic")]
        Basic,
    }
}
