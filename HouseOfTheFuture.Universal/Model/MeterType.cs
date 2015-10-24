using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Flags]
    public enum MeterType
    {
        Other = 0,
        Electricity = 1,
        Water = 2,
        Gas = 4
    }
}
