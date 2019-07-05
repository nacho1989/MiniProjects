using Microsoft.AspNet.SignalR;
using SignalRHubPOC.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRHubPOC.Models
{
    public class XsltCacheBroadcaster : IXsltCacheBroadcaster
    {
        IHubFactory<IHubContext> _factory;

        public XsltCacheBroadcaster(IHubFactory<IHubContext> factory)
        {
            _factory = factory;
        }
        public void ClearXsltCache()
        {
            var hubContext = _factory.CreateHubContext();
            hubContext.Clients.All.ClearXSLTCache();
        }
    }
}