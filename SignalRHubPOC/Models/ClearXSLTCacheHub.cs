using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRHubPOC.Models
{
    [HubName("ClearXSLTCacheHub")]
    public class ClearXSLTCacheHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
          new ConnectionMapping<string>();

        public void ClearXSLTCache()
        {
            string name = Context.QueryString["clientName"];
            string connectionId = Context.ConnectionId;
            var connId = _connections.GetConnections(name).SingleOrDefault(x => x.Equals(connectionId));
            Clients.AllExcept(connId).clearXSLTCache();
        }

        public override Task OnConnected()
        {
            string name = Context.QueryString["clientName"];
            if(!string.IsNullOrEmpty(name))_connections.Add(name, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.QueryString["clientName"];
            if (!string.IsNullOrEmpty(name)) _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.QueryString["clientName"];
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }
    }
}