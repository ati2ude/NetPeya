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

namespace Core.Application.Wallet.Countries.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateUserCommandHandler(
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
                throw new NotFoundException(nameof(Currency), request.ID);
            }

            if (!string.IsNullOrEmpty(request.DefaultCurrencyID.ToString())) entity.DefaultCurrencyID = request.DefaultCurrencyID;
            if (!string.IsNullOrEmpty(request.Name)) entity.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Code)) entity.Code = request.Code;
            if (!string.IsNullOrEmpty(request.PhoneCode)) entity.PhoneCode = request.PhoneCode;

            await _context.SaveChangesAsync(cancellationToken);

            entity.entityState = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return entity;
        }
    }
}
