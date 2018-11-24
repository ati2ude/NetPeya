using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccounts.Commands.CreateWalletAccount
{
    public class CreateWalletAccountCommandHandler : IRequestHandler<CreateWalletAccountCommand, Unit>
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

        public async Task<Unit> Handle(CreateWalletAccountCommand request, CancellationToken cancellationToken)
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

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
