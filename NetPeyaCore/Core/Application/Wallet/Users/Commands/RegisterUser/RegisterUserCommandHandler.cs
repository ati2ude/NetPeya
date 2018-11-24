using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
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
            // Create User Entity
            User user_entity = new User
            {
                CountryID = request.CountryID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                DateOfBirth = request.DateOfBirth,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                IsActive = false
            };

            _context.Users.Add(user_entity);

            await _context.SaveChangesAsync(cancellationToken);

            _context.Entry(user_entity).GetDatabaseValues();

            // Create WalletAccount Entity
            WalletAccount wallet_account_entity = new WalletAccount
            {
                UserID = user_entity.ID,
                CurrencyID = request.CurrencyID,
                WalletAccountCategoryID = 1, // WalletAccount.GetDefault().ID
                WalletAccountCode = WalletAccount.generateWalletAccountCode(user_entity.ID),
                Name = "E-Commerce", // WalletAccount.GetDefault.Name
                Balance = 0,
                IsDefault = true
            };

            _context.WalletAccounts.Add(wallet_account_entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
