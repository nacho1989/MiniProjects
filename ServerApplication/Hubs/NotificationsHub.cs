using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SharedLibrary;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.Hubs
{
    [HubName("NotificationsHub")]
    public class NotificationsHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
           new ConnectionMapping<string>();

        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

        public void Send(WriteToFile message)
        {
            string name = Context.QueryString["UserName"];
            string connectionId = Context.ConnectionId;
            var connId = _connections.GetConnections(name).SingleOrDefault(x => x.Equals(connectionId));

            Clients.AllExcept(connId).sendNotification(message);
        }

        public void NotifySuccess(string message)
        {
            string name = Context.QueryString["UserName"];
            string connectionId = Context.ConnectionId;

            var connId = _connections.GetConnections(name).SingleOrDefault(x => x.Equals(connectionId));
            hubContext.Clients.All.notifyNewUser(message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine($"Hub Connected on {Context.ConnectionId}");

            string name = Context.QueryString["UserName"];
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine($"Hub Disconnected on {Context.ConnectionId}");

            string name = Context.QueryString["UserName"];
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Console.WriteLine($"Hub Reconnected on {Context.ConnectionId}");

            string name = Context.QueryString["UserName"];
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }
    }
}