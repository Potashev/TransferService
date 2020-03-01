using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebApiEFTest.Models;

namespace WebApiEFTest.App_Start
{
    public class AutofacConfig
    {
        public static void Configure() {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<TransferRepository>().As<ITransferRepository>();
            builder.RegisterType<UserManagement>().As<IUserManagement>();

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}