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

namespace Core.Application.Wallet.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly WalletDbContext _context;

        public DeleteCountryCommandHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.ID);
            }

            _context.Countries.Remove(entity);

            await _context.SaveChangesAsync();

            entity.entityState = EntityState.Deleted;

            return entity;
        }
    }
}
