using Core.Application.Exceptions;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.CardTypes.Commands.DeleteCardType
{
    public class DeleteCardTypeCommandHandler : IRequestHandler<DeleteCardTypeCommand, CardType>
    {
        private readonly WalletDbContext _context;

        public DeleteCardTypeCommandHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<CardType> Handle(DeleteCardTypeCommand request, CancellationToken cancellationToken)
        {
            var cardTypeEntity = await _context.CardTypes
                .FindAsync(request.ID);

            if (cardTypeEntity == null)
            {
                return new CardType { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.CardTypes.Remove(cardTypeEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                cardTypeEntity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                cardTypeEntity.statusCode = SharedStatusCodes.Failed;
            }

            return cardTypeEntity;
        }
    }
}
