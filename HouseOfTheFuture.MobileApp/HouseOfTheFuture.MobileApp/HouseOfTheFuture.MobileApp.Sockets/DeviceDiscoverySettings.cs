using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets
{
    public sealed class DeviceDiscoverySettings
    {
        private static DeviceDiscoverySettings _default;

        public DeviceDiscoverySettings(string broadcastIpAddress, int port, int broadcastWaitTimeout, string broadcastRequestDevicesCommand, string broadcastDeviceIdentifierCommand)
        {
            BroadcastIpAddress = broadcastIpAddress;
            BroadcastPort = port;
            BroadcastWaitTimeout = broadcastWaitTimeout;
            BroadcastRequestDevicesCommand = Encoding.UTF8.GetBytes(broadcastRequestDevicesCommand);
            BroadcastDeviceIdentifierCommand = broadcastDeviceIdentifierCommand;
        }

        public string BroadcastIpAddress { get; set; }

        public int BroadcastPort { get; set; }

        public int BroadcastWaitTimeout { get; set; }

        public byte[] BroadcastRequestDevicesCommand { get; set; }

        public string BroadcastDeviceIdentifierCommand { get; set; }


        public static DeviceDiscoverySettings Default => _default ?? (_default = new DeviceDiscoverySettings("239.255.42.99", 5321, 20000, "TT_SEND_DEVICE_INFO", "TT_DEVICE_IDENTIFIER:"));
    }
}
