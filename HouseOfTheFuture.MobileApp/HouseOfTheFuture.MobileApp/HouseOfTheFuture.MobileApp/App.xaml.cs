using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseOfTheFuture.MobileApp.Common;
using HouseOfTheFuture.MobileApp.Sockets;
using HouseOfTheFuture.MobileApp.ViewModel;
using HouseOfTheFuture.MobileApp.Views;
using Xamarin.Forms;

namespace HouseOfTheFuture.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ServiceResolver.Register(DeviceDiscoverySettings.Default);
            this.MainPage = GetMainPage();
        }

        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());


        public static Page GetMainPage()
        {
            return new DeviceSelectionPage();
            //return new MainPage();
        }


        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}