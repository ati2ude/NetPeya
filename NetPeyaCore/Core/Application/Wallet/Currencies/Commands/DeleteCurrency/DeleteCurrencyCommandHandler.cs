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

namespace Core.Application.Wallet.Currencies.Commands.DeleteCurrency
{
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, Currency>
    {
        private readonly WalletDbContext _context;

        public DeleteCurrencyCommandHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<Currency> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .FindAsync(request.CurrencyID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.CurrencyID);
            }

            _context.Currencies.Remove(entity);

            await _context.SaveChangesAsync();

            entity.entityState = EntityState.Deleted;

            return entity;
        }
    }
}
