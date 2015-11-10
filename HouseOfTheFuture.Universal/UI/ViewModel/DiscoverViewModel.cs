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
    public class DiscoverViewModel : ViewModelBase
    {
        private readonly IDiscoverService _discoverService;
        public ObservableCollection<TickTackDevice> Devices { get; } = new ObservableCollection<TickTackDevice>();

        public ICommand DiscoverDevicesCommand => new RelayCommand(DiscoverDevices);

        private void DiscoverDevices()
        {
            _discoverService.DiscoverDevices();
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        public DiscoverViewModel(IDiscoverService discoverService)
        {
            _discoverService = discoverService;
            if (IsInDesignMode)
            {
                Devices.Add(new TickTackDevice() {Sensor = MeterType.Electricity});
                Devices.Add(new TickTackDevice() {Sensor = MeterType.Electricity});
                Devices.Add(new TickTackDevice() {Sensor = MeterType.Electricity});
                Devices.Add(new TickTackDevice() {Sensor = MeterType.Electricity});
            }
        }
    }
}
