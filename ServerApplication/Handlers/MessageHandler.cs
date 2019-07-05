using Microsoft.AspNet.SignalR;
using NServiceBus;
using ServerApplication.Hubs;
using System.Threading.Tasks;

namespace ServerApplication.Handlers
{
    public class MessageHandler : IHandleMessages<object>
    {
        public Task Handle(object message, IMessageHandlerContext context)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

            hubContext.Clients.All.sendNotification(message);

            return Task.CompletedTask;
        }
    }
}