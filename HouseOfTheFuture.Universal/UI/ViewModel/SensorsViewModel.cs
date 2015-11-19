using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Model;
using Services;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class SensorsViewModel : ViewModelBase
    {
        private readonly IHubService _hubService;

        public ObservableCollection<TickTackHub> Hubs { get; } = new ObservableCollection<TickTackHub>();
        public ObservableCollection<Sensor> Sensors { get; } = new ObservableCollection<Sensor>();

        public SensorsViewModel(IHubService hubService)
        {
            _hubService = hubService;

            Hubs.Add(new TickTackHub() { Id = "8D3515FC-94AE-4A49-BBEA-2D8ABCC99967" });
            Hubs.Add(new TickTackHub() { Id = "012029F1-204E-4275-9F39-4FC3D4F46925" });

            SelectedHub = Hubs.First();
        }

        private TickTackHub _selectedHub;
        public TickTackHub SelectedHub
        {
            get { return _selectedHub; }
            set
            {
                if (_selectedHub == value) return;
                _selectedHub = value;
                RaisePropertyChanged();

                GetSensors(_selectedHub);
            }
        }

        private async void GetSensors(TickTackHub hub)
        {
            if (hub.Id == null) return;
            Sensors.Clear();
            var sensors = await _hubService.GetSensors(hub.Id);
            //todo: replace by sensors.ForEach(Sensors.Add);
            foreach (var sensor in sensors)
            { 
                Sensors.Add(sensor);
            }
        }
    }
}
