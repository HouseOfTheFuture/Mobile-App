using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets
{
    public interface IDevice
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Address { get; set; }
    }
}
