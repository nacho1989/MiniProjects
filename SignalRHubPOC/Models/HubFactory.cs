using Microsoft.AspNet.SignalR;
using SignalRHubPOC.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRHubPOC.Models
{
    public class HubFactory : IHubFactory<IHubContext>
    {
        public IHubContext CreateHubContext()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ClearXSLTCacheHub>();
        }
    }
}