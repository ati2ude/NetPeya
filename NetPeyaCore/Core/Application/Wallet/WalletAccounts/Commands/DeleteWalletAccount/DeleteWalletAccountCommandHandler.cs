using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccounts.Commands.DeleteWalletAccount
{
    public class DeleteWalletAccountCommandHandler : IRequestHandler<DeleteWalletAccountCommand, WalletAccount>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteWalletAccountCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<WalletAccount> Handle(DeleteWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var walletAccountEntity = await _context.WalletAccounts
                .FindAsync(request.ID);

            if (walletAccountEntity == null)
            {
                return new WalletAccount { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.WalletAccounts.Remove(walletAccountEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                walletAccountEntity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                walletAccountEntity.statusCode = SharedStatusCodes.Failed;
            }

            return walletAccountEntity;
        }
    }
}
