using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.SavedCards.Queries.GetSingleSavedCard
{
    public class GetSingleSavedCardQueryHandler : IRequestHandler<GetSingleSavedCardQuery, SavedCard>
    {
        private readonly WalletDbContext _context;

        public GetSingleSavedCardQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<SavedCard> Handle(GetSingleSavedCardQuery request, CancellationToken cancellationToken)
        {
            var cardEntity = await _context.SavedCards
                .FindAsync(request.ID);

            if (cardEntity == null)
            {
                return new SavedCard { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            cardEntity.statusCode = SharedStatusCodes.Retrieved;

            return cardEntity;
        }
    }
}
