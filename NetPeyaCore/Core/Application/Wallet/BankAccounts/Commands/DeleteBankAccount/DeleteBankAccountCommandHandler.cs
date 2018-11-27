using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.BankAccounts.Commands.DeleteBankAccount
{
    public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, BankAccount>
    {
        private readonly WalletDbContext _context;

        public DeleteBankAccountCommandHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.BankAccounts
                .FindAsync(request.BankAccountID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BankAccount), request.BankAccountID);
            }

            _context.BankAccounts.Remove(entity);

            await _context.SaveChangesAsync();

            entity.entityState = EntityState.Deleted;

            return entity;
        }
    }
}
