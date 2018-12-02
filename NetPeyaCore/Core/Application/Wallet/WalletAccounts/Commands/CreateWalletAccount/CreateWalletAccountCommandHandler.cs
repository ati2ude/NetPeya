using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccounts.Commands.CreateWalletAccount
{
    public class CreateWalletAccountCommandHandler : IRequestHandler<CreateWalletAccountCommand, WalletAccount>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateWalletAccountCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<WalletAccount> Handle(CreateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new WalletAccount
            {
                UserID = request.UserID,
                CurrencyID = request.CurrencyID,
                WalletAccountCategoryID = request.WalletAccountCategoryID,
                WalletAccountCode = WalletAccount.generateWalletAccountCode(request.UserID),
                Name = request.Name,
                Balance = 0,
                IsDefault = false
            };

            _context.WalletAccounts.Add(entity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                entity.statusCode = SharedStatusCodes.Created;
            }
            else
            {
                entity.statusCode = SharedStatusCodes.Failed;
            }

            return entity;
        }
    }
}
