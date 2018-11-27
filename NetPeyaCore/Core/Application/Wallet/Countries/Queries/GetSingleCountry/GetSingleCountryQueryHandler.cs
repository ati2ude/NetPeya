using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Countries.Queries.GetSingleCountry
{
    public class GetSingleCountryQueryHandler : IRequestHandler<GetSingleCountryQuery, Country>
    {
        private readonly WalletDbContext _context;

        public GetSingleCountryQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetSingleCountryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.ID);
            }

            return entity;
        }
    }
}
