using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCoutrnyCommandHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCoutrnyCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Country
            {
                ID = request.ID,
                DefaultCurrencyID = request.DefaultCurrencyID,
                Name = request.Name,
                Code = request.Code,
                PhoneCode = request.PhoneCode
            };

            _context.Countries.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            entity.entityState = EntityState.Added;

            return entity;
        }
    }
}
