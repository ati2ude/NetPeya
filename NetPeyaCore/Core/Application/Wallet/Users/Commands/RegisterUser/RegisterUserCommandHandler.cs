using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public RegisterUserCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Users.SingleOrDefault(b => b.Email == request.Email);

            if (entity != null)
            {
                throw new DuplicateEntriesException(nameof(User), request.Email);
            }

            // Create User Entity
            User user_entity = new User
            {
                CountryID = request.CountryID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                IsActive = false
            };

            _context.Users.Add(user_entity);

            await _context.SaveChangesAsync(cancellationToken);

            _context.Entry(user_entity).GetDatabaseValues();

            // Create WalletAccount Entity
            var defaultWalletCategory = new WalletAccountCategory().GetWalletAccountCategory(_context);

            WalletAccount wallet_account_entity = new WalletAccount
            {
                UserID = user_entity.ID,
                CurrencyID = request.CurrencyID,
                WalletAccountCategoryID = defaultWalletCategory.ID,
                WalletAccountCode = WalletAccount.generateWalletAccountCode(user_entity.ID),
                Name = defaultWalletCategory.Name,
                Balance = 0,
                IsDefault = true
            };

            _context.WalletAccounts.Add(wallet_account_entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
