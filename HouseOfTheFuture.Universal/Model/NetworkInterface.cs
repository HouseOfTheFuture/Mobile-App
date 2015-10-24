using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace Model
{
    public class NetworkInterface : INetworkInterface
    {
        public IEnumerable<IPAddress> IpAddresses
        {
            get
            {
                var ipAddresses = NetworkInformation.GetHostNames().Where(name => 
                name.IPInformation != null && (name.IPInformation.NetworkAdapter.IanaInterfaceType == 71 || name.IPInformation.NetworkAdapter.IanaInterfaceType == 6)).Select(name => name.DisplayName);

                return ipAddresses.Select(IPAddress.Parse);
            }
        }
    }
}
