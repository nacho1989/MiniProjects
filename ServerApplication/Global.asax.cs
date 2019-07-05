using NServiceBus;
using System.Web.Http;

namespace ServerApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var endpointConfiguration = new EndpointConfiguration("ServerApplication");
            var configHelper = new EndpointConfig();
            configHelper.Customize(endpointConfiguration);

            var Endpoint = NServiceBus.Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
