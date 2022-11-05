using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Log
{
    public class CRUDLog : Log
    {
        /// <summary>
        /// Create, Delete, Update의 타겟이 되는 대상
        /// </summary>
        public object Target { get; set; } = string.Empty;
    }
}
