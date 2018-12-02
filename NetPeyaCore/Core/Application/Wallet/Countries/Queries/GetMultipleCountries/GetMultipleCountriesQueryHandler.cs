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

namespace Core.Application.Wallet.Countries.Queries.GetAllCountries
{
    public class GetMultipleCountriesQueryHandler : IRequestHandler<GetMultipleCountriesQuery, List<Country>>
    {
        private readonly WalletDbContext _context;

        public GetMultipleCountriesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> Handle(GetMultipleCountriesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<Country> countries = _context.Countries.ToList();

            if (countries.Count > 0)
            {
                countries.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            }

            return countries;
        }
    }
}
