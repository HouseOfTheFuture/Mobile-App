using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class ViewModelLocator
    {
        public const string MainPage = "MainPage";
        public const string DeviceSelectionPage = "DeviceSelectionPage";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DeviceSelectionViewModel>();
        }

        /// <summary>
        /// Gets the Main ViewModel.
        /// </summary>
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        /// <summary>
        /// Gets the DeviceSelection ViewModel
        /// </summary>
        public DeviceSelectionViewModel DeviceSelection
            => ServiceLocator.Current.GetInstance<DeviceSelectionViewModel>();
    }
}
