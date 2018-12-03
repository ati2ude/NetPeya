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

namespace Core.Application.Wallet.SavedCards.Queries.GetUserSavedCards
{
    public class GetUserSavedCardsQueryHandler : IRequestHandler<GetUserSavedCardsQuery, List<SavedCard>>
    {
        private readonly WalletDbContext _context;

        public GetUserSavedCardsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<SavedCard>> Handle(GetUserSavedCardsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<SavedCard> savedCards = new List<SavedCard>();

            try
            {
                if (request.UserID != null)
                {
                    savedCards = _context.SavedCards.Where(x => x.UserID == request.UserID).ToList();
                    savedCards.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
                }
                else
                {
                    savedCards = _context.SavedCards.ToList();
                    savedCards.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
                }
            }
            catch (Exception)
            {
                savedCards = null;
            }

            return savedCards;
        }
    }
}
