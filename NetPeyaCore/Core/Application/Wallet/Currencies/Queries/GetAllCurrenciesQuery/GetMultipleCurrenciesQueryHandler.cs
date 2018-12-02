using Core.Application.Exceptions;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Currencies.Queries.GetAllCurrenciesQuery
{
    class GetMultipleCurrenciesQueryHandler : IRequestHandler<GetMultipleCurrenciesQuery, List<Currency>>
    {
        private readonly WalletDbContext _context;

        public GetMultipleCurrenciesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> Handle(GetMultipleCurrenciesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var currencies = _context.Currencies.ToList();

            currencies.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;

            return currencies;
        }
    }
}
