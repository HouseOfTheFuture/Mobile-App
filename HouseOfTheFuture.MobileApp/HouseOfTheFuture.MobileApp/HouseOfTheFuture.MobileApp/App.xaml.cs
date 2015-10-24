using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseOfTheFuture.MobileApp.Views;
using Xamarin.Forms;

namespace HouseOfTheFuture.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            this.MainPage = new MainPage();
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