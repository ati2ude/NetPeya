using Core.Application.Exceptions;
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
            var entity = await _context.CardTypes
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardType), request.ID);
            }

            return entity;
        }
    }
}
