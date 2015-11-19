using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Model;

namespace Services
{
    public interface IDiscoverService
    {
        Task<IEnumerable<TickTackHub>> DiscoverHubs(Action<TickTackHub> deviceFoundCallback = null);
    }
}
