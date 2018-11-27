using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount
{
    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, BankAccount>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateBankAccountCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<BankAccount> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.BankAccounts.SingleOrDefault(b => b.Number == request.Number);

            if (entity != null)
            {
                throw new DuplicateEntriesException(nameof(BankAccount), request.Number);
            }

            var bankEntity = new BankAccount
            {
                UserID = request.UserID,
                Beneficiary = request.Beneficiary,
                Name = request.Name,
                Number = request.Number,
                IBANumber = request.IBANumber,
                SwiftCode = request.SwiftCode,
                Currency = request.Currency,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                Country = request.Country
            };

            _context.BankAccounts.Add(bankEntity);

            await _context.SaveChangesAsync(cancellationToken);

            bankEntity.entityState = EntityState.Added;

            return bankEntity;
        }
    }
}
