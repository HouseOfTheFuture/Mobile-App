using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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

            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.MainPage, typeof(MainPage));
            nav.Configure(ViewModelLocator.DeviceSelectionPage, typeof(DeviceSelectionPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var mainPage = new NavigationPage(new DeviceSelectionPage());

            nav.Initialize(mainPage);

            //SimpleIoc.Default.Register<INavigationService>(() => nav);

            MainPage = mainPage;
        }

        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        
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