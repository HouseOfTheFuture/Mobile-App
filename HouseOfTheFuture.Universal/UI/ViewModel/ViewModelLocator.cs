﻿using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Model;
using Services;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            //register all services
            builder.RegisterAssemblyTypes(typeof(IDiscoverService).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IHubService).GetTypeInfo().Assembly).AsImplementedInterfaces()
                .WithParameter(new TypedParameter(typeof(Uri), App.ApiUri));
            builder.RegisterAssemblyTypes(typeof(INetworkInterface).GetTypeInfo().Assembly).AsImplementedInterfaces();

            //register all viewmodels
            builder
                .RegisterAssemblyTypes(typeof(ViewModelLocator).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .SingleInstance()
                .AsSelf();

            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

        public static DiscoverViewModel Discover => ServiceLocator.Current.GetInstance<DiscoverViewModel>();
        public static AppShellViewModel AppShell => ServiceLocator.Current.GetInstance<AppShellViewModel>();
        public static SensorsViewModel Sensors => ServiceLocator.Current.GetInstance<SensorsViewModel>();
    }
}