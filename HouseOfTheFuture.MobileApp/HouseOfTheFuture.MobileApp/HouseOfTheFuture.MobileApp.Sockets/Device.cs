using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfTheFuture.MobileApp.Sockets
{
    public class Device : IDevice
    {
        public Device(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
