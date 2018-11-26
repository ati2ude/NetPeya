using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Currencies.Queries.GetSingleCurrency
{
    class GetSingleCurrencyQueryHandler : IRequestHandler<GetSingleCurrencyQuery, Currency>
    {
        private readonly WalletDbContext _context;

        public GetSingleCurrencyQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<Currency> Handle(GetSingleCurrencyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .FindAsync(request.CurrencyID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.CurrencyID);
            }

            return entity;
        }
    }
}
