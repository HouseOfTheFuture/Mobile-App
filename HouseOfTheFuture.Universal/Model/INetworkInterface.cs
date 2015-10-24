using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;

namespace Model
{
    public interface INetworkInterface
    {
        IEnumerable<IPAddress> IpAddresses { get; }

    }
}
