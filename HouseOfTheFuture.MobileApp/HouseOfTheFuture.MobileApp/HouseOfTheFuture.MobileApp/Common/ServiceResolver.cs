using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace HouseOfTheFuture.MobileApp.Common
{
    public class ServiceResolver
    {
        private static ISimpleIoc _container;

        static ServiceResolver()
        {
            _container = SimpleIoc.Default;
        }

        public static void Register<TInterface, TClass>() where TInterface : class where TClass : class
        {
            _container.Register<TInterface, TClass>();
        }

        public static void Register<TClass>(TClass instance) where TClass : class
        {
            _container.Register(() => instance);
        }

        public static TInterface Resolve<TInterface>() where TInterface : class
        {
            return _container.GetInstance<TInterface>();
        }
    }
}
