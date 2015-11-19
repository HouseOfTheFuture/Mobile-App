using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Model;
using Newtonsoft.Json;

namespace Services
{
    public class HubService : IHubService
    {
        private readonly Uri _apiUri;

        public HubService(Uri apiUri)
        {
            _apiUri = new Uri(apiUri, "devices/");
        }

        public async Task<IEnumerable<Sensor>> GetSensors(string hubId)
        {
            using (var client = new HttpClient())
            {
                var operation = new Uri(_apiUri, $"{hubId}/sensors");
                var response = await client.GetStringAsync(operation);

                var r = JsonConvert.DeserializeObject<SensorWrapper>(response);

                return r.Sensors;
            }
        }
    }
}
