using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparers
{
    public class StringByLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y) => (x, y) switch
        {
            (null, null) => 0,
            (_, null) => 1,
            (null, _) => -1,
            _ when x.Length > y.Length => 1,
            _ when y.Length > x.Length => -1,
            _ => 0
        };

    }
}
