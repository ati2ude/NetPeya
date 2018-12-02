using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccounts.Commands.UpdateWalletAccount
{
    public class UpdateWalletAccountCommandHandler : IRequestHandler<UpdateWalletAccountCommand, WalletAccount>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateWalletAccountCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<WalletAccount> Handle(UpdateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var walletAccountEntity = _context.WalletAccounts.SingleOrDefault(b => b.ID == request.ID);

            if (walletAccountEntity == null)
            {
                return new WalletAccount { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            if (walletAccountEntity.Name != request.Name) walletAccountEntity.Name = request.Name;
            if (request.WalletAccountCategoryID != null) walletAccountEntity.WalletAccountCategoryID = request.WalletAccountCategoryID;


            if (!_context.Entry(walletAccountEntity).Context.ChangeTracker.HasChanges())
            {
                walletAccountEntity.statusCode = SharedStatusCodes.Unchanged;
                return walletAccountEntity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                walletAccountEntity.statusCode = SharedStatusCodes.Updated;
            }
            else
            {
                walletAccountEntity.statusCode = SharedStatusCodes.Failed;
            }

            return walletAccountEntity;
        }
    }
}
