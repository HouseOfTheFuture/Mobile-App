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

        public ICommand DiscoverDevicesCommand { get; private set; }

        private void DiscoverDevices()
        {
            Devices.Clear();
            _discoverService.DiscoverDevices(async dev => await UIThread.ExecuteAsync(() => Devices.Add(dev)));
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        public DiscoverViewModel(IDiscoverService discoverService)
        {
            DiscoverDevicesCommand = new RelayCommand(DiscoverDevices);
            _discoverService = discoverService;
            if (IsInDesignMode)
            {
                Devices.Add(new TickTackDevice() { Id = Guid.NewGuid().ToString() });
                Devices.Add(new TickTackDevice() { Id = Guid.NewGuid().ToString() });
                Devices.Add(new TickTackDevice() { Id = Guid.NewGuid().ToString() });
                Devices.Add(new TickTackDevice() { Id = Guid.NewGuid().ToString() });
            }
        }
    }
}
