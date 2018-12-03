using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.SavedCards.Commands.DeleteSavedCard
{
    public class DeleteSavedCardCommandHandler : IRequestHandler<DeleteSavedCardCommand, SavedCard>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteSavedCardCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<SavedCard> Handle(DeleteSavedCardCommand request, CancellationToken cancellationToken)
        {
            var cardEntity = await _context.SavedCards
                .FindAsync(request.ID);

            if (cardEntity == null)
            {
                return new SavedCard { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.SavedCards.Remove(cardEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                cardEntity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                cardEntity.statusCode = SharedStatusCodes.Failed;
            }

            return cardEntity;
        }
    }
}
