using Core.Application.Interfaces;
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

namespace Core.Application.Wallet.SavedCards.Commands.UpdateSavedCard
{
    public class UpdateSavedCardCommandHandler : IRequestHandler<UpdateSavedCardCommand, SavedCard>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateSavedCardCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<SavedCard> Handle(UpdateSavedCardCommand request, CancellationToken cancellationToken)
        {
            var cardEntity = _context.SavedCards.SingleOrDefault(b => b.ID == request.ID);

            if (cardEntity == null)
            {
                return new SavedCard { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            if (cardEntity.MaskedNumber != request.MaskedNumber) cardEntity.MaskedNumber = request.MaskedNumber;
            if (cardEntity.CardType != request.CardType) cardEntity.CardType = request.CardType;
            if (cardEntity.ExpiryDate != request.ExpiryDate) cardEntity.ExpiryDate = request.ExpiryDate;



            if (!_context.Entry(cardEntity).Context.ChangeTracker.HasChanges())
            {
                cardEntity.statusCode = SharedStatusCodes.Unchanged;
                return cardEntity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                cardEntity.statusCode = SharedStatusCodes.Updated;
            }
            else
            {
                cardEntity.statusCode = SharedStatusCodes.Failed;
            }

            return cardEntity;
        }
    }
}
