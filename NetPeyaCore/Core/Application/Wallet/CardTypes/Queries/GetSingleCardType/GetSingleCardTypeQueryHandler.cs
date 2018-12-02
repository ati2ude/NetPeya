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

namespace Core.Application.Wallet.CardTypes.Queries.GetSingleCardType
{
    class GetSingleCardTypeQueryHandler : IRequestHandler<GetSingleCardTypeQuery, CardType>
    {
        private readonly WalletDbContext _context;

        public GetSingleCardTypeQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<CardType> Handle(GetSingleCardTypeQuery request, CancellationToken cancellationToken)
        {
            var currencyEntity = await _context.CardTypes
                .FindAsync(request.ID);

            if (currencyEntity == null)
            {
                return new CardType { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            currencyEntity.statusCode = SharedStatusCodes.Retrieved;

            return currencyEntity;
        }
    }
}
