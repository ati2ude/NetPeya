using Core.Application.Exceptions;
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
    class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, List<Currency>>
    {
        private readonly WalletDbContext _context;

        public GetAllCurrenciesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var currencies = _context.Currencies.ToList();

            return currencies;
        }
    }
}
