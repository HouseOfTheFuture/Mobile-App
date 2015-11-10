using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HouseOfTheFuture.MobileApp.Common;
using HouseOfTheFuture.MobileApp.Sockets;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class DeviceSelectionViewModel : ViewModelBase
    {
        private IDeviceDiscoveryService _deviceDiscoveryService;
        public DeviceSelectionViewModel(IDeviceDiscoveryService deviceDiscoveryService)
        {
            RefreshDevicesCommand = new RelayCommand(RefreshDevices);
            Devices = new ObservableCollection<string>();

            _deviceDiscoveryService = deviceDiscoveryService;
            _deviceDiscoveryService.DeviceFound += DeviceDiscoveryServiceOnDeviceFound;
        }

        private void DeviceDiscoveryServiceOnDeviceFound(object sender, DeviceFoundEventArgs es)
        {
            Devices.Add(es.DeviceIdentifier);
        }

        public ObservableCollection<string> Devices { get; set; }
        
        public RelayCommand RefreshDevicesCommand { get; set; }

        private Boolean _isBusy;
        public Boolean IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected async void RefreshDevices()
        {
            IsBusy = true;

            Devices.Clear();

            var devices = await _deviceDiscoveryService.DiscoverDevices();

            IsBusy = false;
        }
    }
}
