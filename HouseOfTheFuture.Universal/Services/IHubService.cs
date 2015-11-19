using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public interface IHubService
    {
        Task<IEnumerable<Sensor>> GetSensors(string hubId, Action<Sensor> sensorFoundCallback = null);
    }
}
