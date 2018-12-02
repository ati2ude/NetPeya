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
            var currencyEntity = await _context.Currencies
                .FindAsync(request.ID);

            if (currencyEntity == null)
            {
                return new Currency { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.Currencies.Remove(currencyEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                currencyEntity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                currencyEntity.statusCode = SharedStatusCodes.Failed;
            }

            return currencyEntity;
        }
    }
}
