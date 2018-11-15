using Core.Application.Interfaces;
using Core.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Core.Infrustructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
