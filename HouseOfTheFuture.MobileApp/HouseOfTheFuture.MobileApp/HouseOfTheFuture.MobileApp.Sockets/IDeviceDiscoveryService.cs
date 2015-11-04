using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets
{
    public interface IDeviceDiscoveryService : IDisposable
    {
        Task<IEnumerable<IDevice>> GetDevices();
    }
}
