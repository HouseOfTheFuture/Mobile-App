using System.Collections.Generic;
using System.Net;

namespace Model
{
    public interface INetworkInterface
    {
        IEnumerable<IPAddress> IpAddresses { get; }
    }
}
