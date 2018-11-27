using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.CardTypes.Commands.UpdateCardType
{
    public class UpdateCardTypeCommandHandler : IRequestHandler<UpdateCardTypeCommand, CardType>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateCardTypeCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<CardType> Handle(UpdateCardTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.CardTypes.SingleOrDefault(b => b.ID == request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardType), request.ID);
            }

            if (!string.IsNullOrEmpty(request.Name)) entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            entity.entityState = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return entity;
        }
    }
}
