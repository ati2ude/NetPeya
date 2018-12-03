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

namespace Core.Application.Wallet.SavedCards.Commands.CreateSavedCard
{
    public class CreateSavedCardCommandHandler : IRequestHandler<CreateSavedCardCommand, SavedCard>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateSavedCardCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<SavedCard> Handle(CreateSavedCardCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.SavedCards.Where(e => e.MaskedNumber == request.MaskedNumber).FirstOrDefault();

            if (entity != null)
            {
                entity.statusCode = SharedStatusCodes.Exists;
                return entity;
            }

            var savedCard = new SavedCard
            {
                UserID = request.UserID,
                CardType = request.CardType,
                MaskedNumber = request.MaskedNumber,
                ExpiryDate = request.ExpiryDate
            };

            _context.SavedCards.Add(savedCard);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                savedCard.statusCode = SharedStatusCodes.Created;
            }
            else
            {
                savedCard.statusCode = SharedStatusCodes.Failed;
            }

            return savedCard;
        }
    }
}
