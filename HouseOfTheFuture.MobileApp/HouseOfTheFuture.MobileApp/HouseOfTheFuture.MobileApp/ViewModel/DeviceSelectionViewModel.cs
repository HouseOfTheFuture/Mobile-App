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
            Devices = new ObservableCollection<IDevice>();

            _deviceDiscoveryService = deviceDiscoveryService;
            _deviceDiscoveryService.DeviceFound += DeviceDiscoveryServiceOnDeviceFound;
        }

        private void DeviceDiscoveryServiceOnDeviceFound(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("Device found");
        }

        public ObservableCollection<IDevice> Devices { get; set; }
        
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

            var devices = await _deviceDiscoveryService.DiscoverDevices();

            IsBusy = false;
        }
    }
}
