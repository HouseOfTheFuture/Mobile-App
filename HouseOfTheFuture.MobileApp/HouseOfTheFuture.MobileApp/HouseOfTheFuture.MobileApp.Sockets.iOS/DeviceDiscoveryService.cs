using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets.iOS
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        private readonly IPAddress _broadcastIp;
        private IPEndPoint _endpoint;
        private Socket _multicastSocket;
        private Socket _listeningSocket;
        private DeviceDiscoverySettings _settings;

        public DeviceDiscoveryService(DeviceDiscoverySettings settings)
        {
            _broadcastIp = IPAddress.Parse(settings.BroadcastIpAddress);
            _endpoint = new IPEndPoint(_broadcastIp, settings.BroadcastPort);

            _multicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_broadcastIp));
            _multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            _multicastSocket.Connect(_endpoint);

            _listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint receiveEndpoint = new IPEndPoint(IPAddress.Any, settings.BroadcastPort);
            _listeningSocket.Bind(receiveEndpoint);
            _listeningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_broadcastIp, IPAddress.Any));

            _settings = settings;
        }

        public async Task<IEnumerable<IDevice>> GetDevices()
        {
            _multicastSocket.Send(_settings.BroadcastRequestDevicesCommand);

            var devices = new List<IDevice>();

            Task.Run(() =>
            {
                while (true)
                {
                    byte[] be = new byte[1024];
                    try
                    {
                        _listeningSocket.Receive(be);
                    }
                    catch { }
                    string str = Encoding.UTF8.GetString(be, 0, be.Length);
                    devices.Add(new Device(Guid.NewGuid(), str, "0.0.0.0"));
                }
            }).Wait(10000);

            return devices;
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
                if (_multicastSocket != null)
                {
                    _multicastSocket.Close();
                    _multicastSocket = null;
                }

                if (_listeningSocket != null)
                {
                    _listeningSocket.Close();
                    _multicastSocket = null;
                }
            }
            // free native resources if there are any.
        }
    }
}
