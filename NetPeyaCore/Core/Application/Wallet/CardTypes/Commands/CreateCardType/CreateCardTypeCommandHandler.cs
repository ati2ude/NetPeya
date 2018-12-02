using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.CardTypes.Commands.CreateCardType
{
    public class CreateCardTypeCommandHandler : IRequestHandler<CreateCardTypeCommand, CardType>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCardTypeCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<CardType> Handle(CreateCardTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.CardTypes.SingleOrDefault(b => b.Name == request.Name);

            if (entity != null)
            {
                entity.statusCode = SharedStatusCodes.Exists;
                return entity;
            }

            var cardTypeEntity = new CardType
            {
                Name = request.Name
            };

            _context.CardTypes.Add(cardTypeEntity);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                cardTypeEntity.statusCode = SharedStatusCodes.Created;
            }
            else
            {
                cardTypeEntity.statusCode = SharedStatusCodes.Failed;
            }

            return cardTypeEntity;
        }
    }
}
