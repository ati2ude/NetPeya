using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletApplication.Notifications.Models;

namespace WalletApplication.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
