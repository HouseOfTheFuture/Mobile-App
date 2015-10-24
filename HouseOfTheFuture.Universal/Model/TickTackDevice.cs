using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Model
{
    public class TickTackDevice
    {
        public string Name { get; set; }
        public EndpointPair Endpoint { get; set; }
    }
}
