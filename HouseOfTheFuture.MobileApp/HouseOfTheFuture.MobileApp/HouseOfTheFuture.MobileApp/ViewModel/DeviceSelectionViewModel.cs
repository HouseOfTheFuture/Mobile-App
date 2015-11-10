using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HouseOfTheFuture.MobileApp.Sockets;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class DeviceSelectionViewModel : ViewModelBase
    {
        public DeviceSelectionViewModel()
        {
            RefreshDevicesCommand = new RelayCommand(RefreshDevices);
        }

        private ObservableCollection<IDevice> _devices = new ObservableCollection<IDevice>();
        public ObservableCollection<IDevice> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                RaisePropertyChanged();
            }
        }

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

            await Task.Delay(2000);

            Devices.Add(new Device(Guid.NewGuid(),
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(DateTime.UtcNow.Ticks.ToString())), "0.0.0.0"));

            IsBusy = false;
        }
    }
}
