using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets
{
    public class DeviceFoundEventArgs : EventArgs
    {
        public string DeviceIdentifier { get; set; }
    }
}
