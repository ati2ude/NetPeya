using Core.Application.Exceptions;
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
            var entity = await _context.CardTypes
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardType), request.ID);
            }

            _context.CardTypes.Remove(entity);

            await _context.SaveChangesAsync();

            entity.entityState = EntityState.Deleted;

            return entity;
        }
    }
}
