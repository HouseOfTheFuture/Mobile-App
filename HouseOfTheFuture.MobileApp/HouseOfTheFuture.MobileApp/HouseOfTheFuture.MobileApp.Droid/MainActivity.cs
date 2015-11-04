using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HouseOfTheFuture.MobileApp.Common;
using HouseOfTheFuture.MobileApp.Sockets;
using HouseOfTheFuture.MobileApp.Sockets.Droid;

namespace HouseOfTheFuture.MobileApp.Droid
{
    [Activity(Label = "HouseOfTheFuture.MobileApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            ServiceResolver.Register<IDeviceDiscoveryService, DeviceDiscoveryService>();

            LoadApplication(new App());
        }
    }
}

