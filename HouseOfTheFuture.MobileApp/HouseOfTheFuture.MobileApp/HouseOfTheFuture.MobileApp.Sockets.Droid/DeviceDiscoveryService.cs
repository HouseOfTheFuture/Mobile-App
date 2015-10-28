using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Java.Net;

namespace HouseOfTheFuture.MobileApp.Sockets.Droid
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        private const int Port = 5321;
        private readonly IPAddress _broadcastIp;
        private IPEndPoint _endpoint;
        private UdpClient _client;

        public DeviceDiscoveryService(DeviceDiscoverySettings settings)
        {
            _broadcastIp = IPAddress.Parse(settings.BroadcastIpAddress);
            _client = new UdpClient(settings.BroadcastPort);
            _endpoint = new IPEndPoint(_broadcastIp, settings.BroadcastPort);
            _client.JoinMulticastGroup(_broadcastIp);
        }

        public Task<IEnumerable<IDevice>> GetDevices()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DeviceDiscoveryService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                }
            }
            // free native resources if there are any.
        }
    }
}
