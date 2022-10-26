using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Shared
{
    internal static class Extensions
    {
        public static int AsInt(this string s, int byDefault = 0)
        {
            int result;
            if (s == null)
                return byDefault;
            else if(int.TryParse(s, out result))
                return result;
            else return byDefault;
        }
    }
}
