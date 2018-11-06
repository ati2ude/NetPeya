using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletApplication.Interfaces;
using WalletApplication.Notifications.Models;

namespace WalletInfrustructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
