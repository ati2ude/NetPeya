using Core.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
