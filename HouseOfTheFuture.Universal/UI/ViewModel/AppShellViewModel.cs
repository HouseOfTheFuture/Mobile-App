using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using InfoSupport.TickTack.App.Views;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class AppShellViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();

        public AppShellViewModel()
        {
            Menu.Add(new MenuItem() { Glyph = "", Text = "Home", NavigationDestination = typeof(HomeView) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Discover", NavigationDestination = typeof(DiscoverView) });
        }
    }
}
