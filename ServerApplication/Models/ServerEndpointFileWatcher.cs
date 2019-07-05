using NServiceBus;
using NServiceBus.Features;
using SharedLibrary;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class ServerEndpointFileWatcher : Feature
    {
        static String _directoryName = ConfigurationManager.AppSettings["deployDirectory"];

        public void InitializeFileWatcher()
        {
            throw new NotImplementedException();
        }

        protected override void Setup(FeatureConfigurationContext context)
        {
            throw new NotImplementedException();
        }
    }
}