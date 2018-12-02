using Core.Application.Exceptions;
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

namespace Core.Application.Wallet.Countries.Commands.UpdateUser
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateCountryCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Countries.SingleOrDefault(b => b.ID == request.ID);

            if (entity == null)
            {
                return new Country { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            if (request.DefaultCurrencyID != null) entity.DefaultCurrencyID = request.DefaultCurrencyID;
            if (request.Name != null) entity.Name = request.Name;
            if (request.Code != null) entity.Code = request.Code;
            if (request.PhoneCode != null) entity.PhoneCode = request.PhoneCode;

            if (!_context.Entry(entity).Context.ChangeTracker.HasChanges())
            {
                entity.statusCode = SharedStatusCodes.Unchanged;
                return entity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                entity.statusCode = SharedStatusCodes.Updated;
            }
            else
            {
                entity.statusCode = SharedStatusCodes.Failed;
            }

            return entity;
        }
    }
}
