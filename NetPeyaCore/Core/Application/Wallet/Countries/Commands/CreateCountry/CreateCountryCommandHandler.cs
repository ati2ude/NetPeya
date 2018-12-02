using Core.Application.Exceptions;
using Core.Application.Interfaces;
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
            var entity = _context.Countries.SingleOrDefault(b => b.Name == request.Name);

            if (entity != null)
            {
                throw new DuplicateEntriesException(nameof(Country), request.Name);
            }

            var countryEntity = new Country
            {
                DefaultCurrencyID = request.DefaultCurrencyID,
                Name = request.Name,
                Code = request.Code,
                PhoneCode = request.PhoneCode
            };

            _context.Countries.Add(countryEntity);

            await _context.SaveChangesAsync(cancellationToken);

            return countryEntity;
        }
    }
}
