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
            var container = new ContainerBuilder();

            //register all services
            container.RegisterAssemblyTypes(typeof (IDiscoverService).GetTypeInfo().Assembly).AsImplementedInterfaces();

            //register all viewmodels
            container
                .RegisterAssemblyTypes(typeof (ViewModelLocator).GetTypeInfo().Assembly)
                .Where(t =>t.Name.EndsWith("ViewModel"))
                .AsSelf();

            var autofacServiceLocator = new AutofacServiceLocator(container.Build());
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }

        public static DiscoverViewModel Discover => ServiceLocator.Current.GetInstance<DiscoverViewModel>();
        public static AppShellViewModel AppShell => ServiceLocator.Current.GetInstance<AppShellViewModel>();
    }
}