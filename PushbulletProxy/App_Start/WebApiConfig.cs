using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PushbulletProxy.Bootstrapper;
using PushbulletProxy.Core;
using PushbulletProxy.Core.Services;
using PushbulletProxy.Core.Validators;
using PushbulletProxy.Services;
using PushbulletProxy.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace PushbulletProxy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Unity dependency injection container
            var container = new UnityContainer();

            // Register dependencies
            container.RegisterType<IUserManager, UserManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPushbulletClient, PushbulletClient>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserValidator, UserValidator>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISettings, Settings>(new ContainerControlledLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Ensure the output is returned as JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Camel-case and indentation settings
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            };  

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/pushbulletproxy/{controller}/"
            );
        }
    }
}
