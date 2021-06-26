using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStruct
{
    public class TimeStructComparer : IComparer<Time>
    {
        public int Compare(Time x, Time y) => (x.Hours * 100 + x.Minutes) - (y.Hours * 100 + y.Minutes);
    }
}
