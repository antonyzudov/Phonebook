﻿using Domain.Abstract;
using Microsoft.Practices.Unity;
using PhonebookApp.Business;
using PhonebookApp.Business.Abstract;
using PhonebookApp.Domain;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace PhonebookApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(), 
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve);

            config.DependencyResolver = new UnityResolver(container);

            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "PhonebookApp/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private class UnityResolver : IDependencyResolver
        {
            protected IUnityContainer container;

            public UnityResolver(IUnityContainer container)
            {
                if (container == null)
                {
                    throw new ArgumentNullException("container");
                }
                this.container = container;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return container.Resolve(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return container.ResolveAll(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return new List<object>();
                }
            }

            public IDependencyScope BeginScope()
            {
                var child = container.CreateChildContainer();
                return new UnityResolver(child);
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                container.Dispose();
            }
        }
    }
}



