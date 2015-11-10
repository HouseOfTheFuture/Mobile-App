using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InfoSupport.TickTack.App.Views;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class AppShellViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();

        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            private set
            {
                _isPaneOpen = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ShowMenu => new RelayCommand(() => IsPaneOpen = !IsPaneOpen);

        public AppShellViewModel()
        {
            Menu.Add(new MenuItem() { Glyph = "", Text = "Home", NavigationDestination = typeof(HomeView) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Discover", NavigationDestination = typeof(DiscoverView) });
        }
    }
}
