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

            var countryEntity = await _context.Countries
                .FindAsync(request.ID);

            if (countryEntity == null)
            {
                return new Country { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            countryEntity.statusCode = SharedStatusCodes.Retrieved;

            return countryEntity;
        }
    }
}
