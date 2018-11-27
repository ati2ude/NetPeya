using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<Country>>
    {
        private readonly WalletDbContext _context;

        public GetAllCountriesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var currencies = _context.Countries.ToList();

            return currencies;
        }
    }
}
