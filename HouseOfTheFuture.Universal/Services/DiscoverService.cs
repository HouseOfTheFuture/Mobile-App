using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Model;

namespace Services
{
    public class DiscoverService : IDiscoverService
    {
        private const string BroadcastAddress = "239.255.42.99";
        private const string RemoteServiceName = "5321";
        private Action<TickTackDevice> _deviceFoundCallback;


        public async Task<IEnumerable<TickTackDevice>> DiscoverDevices(Action<TickTackDevice> deviceFoundCallback = null)
        {
            _deviceFoundCallback = deviceFoundCallback;
            await ListenForTack();
            await SendTick();
            //todo: send complete list
            return new List<TickTackDevice>().AsEnumerable();
        }

        private async Task SendTick()
        {
            using (var socket = new DatagramSocket())
            {
                await socket.BindServiceNameAsync(string.Empty);
                socket.JoinMulticastGroup(new HostName(BroadcastAddress));
                var outputStream =
                    await socket.GetOutputStreamAsync(new HostName(BroadcastAddress), RemoteServiceName);
                var buffer = Encoding.UTF8.GetBytes("TT_SEND_DEVICE_INFO");
                await outputStream.WriteAsync(buffer.AsBuffer());
                await outputStream.FlushAsync();
                Debug.WriteLine("TICK Broadcasted to {0}:{1}", BroadcastAddress, RemoteServiceName);
            }
        }

        private async Task<DatagramSocket> ListenForTack()
        {
            var socket = new DatagramSocket();
            socket.MessageReceived += Socket_MessageReceived;
            await socket.BindServiceNameAsync(RemoteServiceName);
            Debug.WriteLine("Listening on {0}", RemoteServiceName);
            return socket;
        }

        private void Socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            var dataReader = args.GetDataReader();
            var length = dataReader.UnconsumedBufferLength;
            var message = dataReader.ReadString(length);
            var guidAsString = message.Replace("TT_DEVICE_IDENTIFIER:", "").Trim();
            _deviceFoundCallback?.Invoke(new TickTackDevice { Id = guidAsString });
        }
    }
}
