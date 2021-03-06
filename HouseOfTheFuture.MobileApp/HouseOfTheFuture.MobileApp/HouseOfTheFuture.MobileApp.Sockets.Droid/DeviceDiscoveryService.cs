using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets.Droid
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        private readonly IPAddress _broadcastIp;
        private readonly IPEndPoint _endpoint;
        private readonly Socket _listeningSocket;
        private Socket _multicastSocket;
        private readonly DeviceDiscoverySettings _settings;

        public DeviceDiscoveryService(DeviceDiscoverySettings settings)
        {
            _broadcastIp = IPAddress.Parse(settings.BroadcastIpAddress);
            _endpoint = new IPEndPoint(_broadcastIp, settings.BroadcastPort);

            _multicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                new MulticastOption(_broadcastIp));
            _multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            _multicastSocket.Connect(_endpoint);

            _listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            var receiveEndpoint = new IPEndPoint(IPAddress.Any, settings.BroadcastPort);
            _listeningSocket.Bind(receiveEndpoint);
            _listeningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                new MulticastOption(_broadcastIp, IPAddress.Any));

            _settings = settings;
        }

        public event EventHandler<DeviceFoundEventArgs> DeviceFound;

        public Task<IEnumerable<string>> DiscoverDevices()
        {
            _multicastSocket.Send(_settings.BroadcastRequestDevicesCommand);

            var tcs = new TaskCompletionSource<IEnumerable<string>>();

            var devices = new List<string>();


            Task.Run(() =>
            {
                var isCompleted = false;

                using (var t = new Timer(state =>
                {
                    isCompleted = true;
                }, null, TimeSpan.FromMilliseconds(_settings.BroadcastWaitTimeout),
                    TimeSpan.FromMilliseconds(_settings.BroadcastWaitTimeout)))
                {
                    while (!isCompleted)
                    {
                        var be = new byte[57];
                        try
                        {
                            _listeningSocket.ReceiveTimeout = 1000;
                            _listeningSocket.Receive(be);
                            var str = Encoding.UTF8.GetString(be, 0, be.Length);
                            if (!string.IsNullOrWhiteSpace(str) && str.StartsWith(_settings.BroadcastDeviceIdentifierCommand))
                            {
                                var deviceIdentifier = str.Substring(_settings.BroadcastDeviceIdentifierCommand.Length);
                                devices.Add(deviceIdentifier);
                                DeviceFound?.Invoke(this, new DeviceFoundEventArgs() { DeviceIdentifier = deviceIdentifier });
                            }
                        }
                        catch
                        {
                        }
                    }
                    tcs.SetResult(devices);
                }
            });
            return tcs.Task;
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