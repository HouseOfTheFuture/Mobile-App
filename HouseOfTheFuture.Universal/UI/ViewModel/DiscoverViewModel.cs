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
        public ObservableCollection<TickTackHub> Hubs { get; } = new ObservableCollection<TickTackHub>();

        public ICommand DiscoverDevicesCommand { get; private set; }

        private void DiscoverDevices()
        {
            Hubs.Clear();
            _discoverService.DiscoverHubs(async dev => await UIThread.ExecuteAsync(() => Hubs.Add(dev)));
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
                Hubs.Add(new TickTackHub() { Id = Guid.NewGuid().ToString() });
                Hubs.Add(new TickTackHub() { Id = Guid.NewGuid().ToString() });
                Hubs.Add(new TickTackHub() { Id = Guid.NewGuid().ToString() });
                Hubs.Add(new TickTackHub() { Id = Guid.NewGuid().ToString() });
            }
        }
    }
}
