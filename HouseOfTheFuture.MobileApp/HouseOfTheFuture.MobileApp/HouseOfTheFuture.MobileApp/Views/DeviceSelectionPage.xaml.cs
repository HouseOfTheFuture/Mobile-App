using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HouseOfTheFuture.MobileApp.Views
{
    public partial class DeviceSelectionPage : ContentPage
    {
        public DeviceSelectionPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.DeviceSelection;
        }
    }
}
