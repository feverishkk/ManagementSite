using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Log
{
    public class Log
    {
        public string Path { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Method { get; set; }
        public string UserName { get; set; }
        public string RemoteIpAddress { get; set; }
        public string StatusCode { get; set; }
    }
}
