using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HouseOfTheFuture.MobileApp.Sockets;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class DeviceSelectionViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDeviceDiscoveryService _deviceDiscoveryService;
        public DeviceSelectionViewModel(IDeviceDiscoveryService deviceDiscoveryService, INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));
            _navigationService = navigationService;

            RefreshDevicesCommand = new RelayCommand(RefreshDevices);
            //SelectDeviceCommand = new RelayCommand(SelectDevice);
            Devices = new List<string>() { Guid.NewGuid().ToString() , Guid.NewGuid().ToString() , Guid.NewGuid().ToString() , Guid.NewGuid().ToString() };

            _deviceDiscoveryService = deviceDiscoveryService;
            _deviceDiscoveryService.DeviceFound += DeviceDiscoveryServiceOnDeviceFound;
        }

        private void DeviceDiscoveryServiceOnDeviceFound(object sender, DeviceFoundEventArgs es)
        {
            Devices.Add(es.DeviceIdentifier);
        }

        public List<string> Devices { get; set; }
        
        public RelayCommand RefreshDevicesCommand { get; set; }

        //public RelayCommand SelectDeviceCommand { get; set; }

        private string _selectedDeviceId;
        public string SelectedDeviceId
        {
            get { return _selectedDeviceId; }
            set
            {
                if (_selectedDeviceId != value)
                {
                    _selectedDeviceId = value;
                    RaisePropertyChanged();
                    SelectDevice();
                }
            }
        }

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

            await _deviceDiscoveryService.DiscoverDevices();

            IsBusy = false;
        }

        protected void SelectDevice()
        {
            _navigationService.NavigateTo(ViewModelLocator.MainPage, SelectedDeviceId);
        }
    }
}
