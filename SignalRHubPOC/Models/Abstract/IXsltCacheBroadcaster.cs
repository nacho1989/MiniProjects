using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHubPOC.Models.Abstract
{
    public interface IXsltCacheBroadcaster : IBroadcaster
    {
        void ClearXsltCache();
    }
}
