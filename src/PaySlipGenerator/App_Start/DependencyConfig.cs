using Autofac;
using Autofac.Integration.WebApi;
using PaySlipGenerator.Services;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace PaySlipGenerator.App_Start
{
    public class DependencyConfig
    {

       public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PaySlipCalculator>().As<IPaySlipCalculator>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}