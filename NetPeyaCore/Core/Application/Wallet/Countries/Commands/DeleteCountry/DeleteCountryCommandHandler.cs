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
                return new Country { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.Countries.Remove(entity);

            if (await _context.SaveChangesAsync() > 0)
            {
                entity.statusCode = SharedStatusCodes.Deleted;
            }
            else
            {
                entity.statusCode = SharedStatusCodes.Failed;
            }

            return entity;
        }
    }
}
