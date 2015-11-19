using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SensorWrapper
    {
        public Sensor[] Sensors { get; set; }
    }

    public class Sensor
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
