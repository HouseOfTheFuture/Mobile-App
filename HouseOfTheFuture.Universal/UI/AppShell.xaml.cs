using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using InfoSupport.TickTack.App.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InfoSupport.TickTack.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem != null)
                {
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

        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                SplitView.IsPaneOpen = true;
            }
        }

        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                SplitView.IsPaneOpen = false;
            }
        }

    }
}
