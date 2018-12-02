using Core.Application.Exceptions;
using Core.Application.StatusCodes;
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
            var currencyEntity = await _context.Currencies
                .FindAsync(request.CurrencyID);

            if (currencyEntity == null)
            {
                return new Currency { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            currencyEntity.statusCode = SharedStatusCodes.Retrieved;

            return currencyEntity;
        }
    }
}
