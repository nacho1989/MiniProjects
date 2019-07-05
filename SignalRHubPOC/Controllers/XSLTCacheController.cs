using Microsoft.AspNet.SignalR;
using SignalRHubPOC.Models;
using SignalRHubPOC.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRHubPOC.Controllers
{
    [Route("XSLTCache")]
    public class XSLTCacheController : ApiController
    {
        IXsltCacheBroadcaster _broadcaster;

        public XSLTCacheController(IXsltCacheBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        [HttpGet]
        [Route("ClearCache")]
        public void ClearCache()
        {
            _broadcaster.ClearXsltCache();
        }
    }
}
