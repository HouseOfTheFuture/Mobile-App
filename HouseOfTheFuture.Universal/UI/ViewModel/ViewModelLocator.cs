using System.Diagnostics;
using System.Reflection;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Services;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            //register all services
            builder.RegisterAssemblyTypes(typeof (IDiscoverService).GetTypeInfo().Assembly).AsImplementedInterfaces();

            //register all viewmodels
            builder
                .RegisterAssemblyTypes(typeof (ViewModelLocator).GetTypeInfo().Assembly)
                .Where(t =>t.Name.EndsWith("ViewModel"))
                .SingleInstance()
                .AsSelf();

            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

        public static DiscoverViewModel Discover => ServiceLocator.Current.GetInstance<DiscoverViewModel>();
        public static AppShellViewModel AppShell => ServiceLocator.Current.GetInstance<AppShellViewModel>();
    }
}