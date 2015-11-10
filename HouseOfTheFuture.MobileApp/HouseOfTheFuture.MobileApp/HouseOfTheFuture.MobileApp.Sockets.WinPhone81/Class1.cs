using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace HouseOfTheFuture.MobileApp.Sockets.WinPhone81
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        public event EventHandler<DeviceFoundEventArgs> DeviceFound;

        public DeviceDiscoveryService(DeviceDiscoverySettings settings)
        {

        }

        public Task<IEnumerable<IDevice>> DiscoverDevices()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
