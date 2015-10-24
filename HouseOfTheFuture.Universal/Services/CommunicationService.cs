using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Model;

namespace Services
{
    public class CommunicationService : ICommunicationService
    {
        //private const string MulticastAddress = "239.255.42.99";
        //private const string Port = "5321";

        public Task<IEnumerable<TickTackDevice>> DiscoverDevices()
        {
            return new Task<IEnumerable<TickTackDevice>>(() => new List<TickTackDevice>());
        }

        public Task ListenTo(TickTackDevice device)
        {
            throw new NotImplementedException();
        }
    }
}
