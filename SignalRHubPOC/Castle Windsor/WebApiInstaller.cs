using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SignalRHubPOC.Models;
using SignalRHubPOC.Models.Abstract;
using System.Web.Http.Controllers;

namespace SignalRHubPOC.Castle_Windsor
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<IHttpController>()
                            .LifestylePerWebRequest());
            container.Register(
                    Component.For(typeof(IXsltCacheBroadcaster)).ImplementedBy<XsltCacheBroadcaster>().LifestylePerWebRequest(),
                    Classes.FromThisAssembly()
                       .BasedOn(typeof(IHubFactory<>))
                       .WithServiceAllInterfaces()
                );
        }
    }
}