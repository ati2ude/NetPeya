using Core.Application.Exceptions;
using Core.Application.StatusCodes;
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
                .FindAsync(request.ID);

            if (entity == null)
            {
                return new BankAccount { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.BankAccounts.Remove(entity);

            if (await _context.SaveChangesAsync() > 0)
            {
                entity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                entity.statusCode = SharedStatusCodes.Failed;
            }

            return entity;
        }
    }
}
