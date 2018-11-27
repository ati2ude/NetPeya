using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount.UpdateBankAccount;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.BankAccounts.Commands.UpdateBankAccount
{
    class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, BankAccount>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateBankAccountCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<BankAccount> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.BankAccounts.SingleOrDefault(b => b.ID == request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BankAccount), request.ID);
            }

            if (!string.IsNullOrEmpty(request.Beneficiary)) entity.Beneficiary = request.Beneficiary;
            if (!string.IsNullOrEmpty(request.Name)) entity.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Number)) entity.Number = request.Number;
            if (!string.IsNullOrEmpty(request.IBANumber)) entity.IBANumber = request.IBANumber;
            if (!string.IsNullOrEmpty(request.SwiftCode)) entity.SwiftCode = request.SwiftCode;
            if (!string.IsNullOrEmpty(request.Currency)) entity.Currency = request.Currency;
            if (!string.IsNullOrEmpty(request.AddressLine1)) entity.AddressLine1 = request.AddressLine1;
            if (!string.IsNullOrEmpty(request.AddressLine2)) entity.AddressLine2 = request.AddressLine2;
            if (!string.IsNullOrEmpty(request.City)) entity.City = request.City;
            if (!string.IsNullOrEmpty(request.Country)) entity.Country = request.Country;

            if (request.IsDefault)
            {
                foreach (var crr in _context.BankAccounts.Where(x => x.UserID == request.UserID).ToList())
                {
                    crr.IsDefault = false;
                }
            }

            entity.IsDefault = request.IsDefault;

            await _context.SaveChangesAsync(cancellationToken);

            entity.entityState = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return entity;
        }
    }
}
