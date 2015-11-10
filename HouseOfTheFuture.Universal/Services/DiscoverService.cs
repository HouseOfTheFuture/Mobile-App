using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public class DiscoverService : IDiscoverService
    {
        //private const string MulticastAddress = "239.255.42.99";
        //private const string Port = "5321";

        public Task<IEnumerable<TickTackDevice>> DiscoverDevices(Action<TickTackDevice> callback = null)
        {
            //dummy test implementation
            new Timer(state => callback(new TickTackDevice() { Id = Guid.NewGuid().ToString()}), null, 0, 1000);
            return Task.FromResult(new List<TickTackDevice>().AsEnumerable());
        }

        public Task ListenTo(TickTackDevice device)
        {
            throw new NotImplementedException();
        }
    }
}