using System.Linq;
using Windows.UI.Xaml.Controls;
using InfoSupport.TickTack.App.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InfoSupport.TickTack.App
{
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            var menuItem = e.AddedItems.First() as MenuItem;
            if (menuItem == null) return;

            if (menuItem.IsNavigation)
            {
                SplitViewFrame.Navigate(menuItem.NavigationDestination);
            }
            else
            {
                menuItem.Command.Execute(null);
            }
        }
    }
}